using System.Collections;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;


public class Enemy1Behavior : MonoBehaviour, IUpdatable
{
    [SerializeField] private SpriteFlipper spriteFlipper;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float minMoveTime = 2f;
    [SerializeField] private float maxMoveTime = 5f;
    private float detectionRange = 20f; 

    private bool isMoving = true;
    private bool isMovingToTarget = false;
    private bool isAttacking = false; 
    private bool playerDetected = false;

    private Rigidbody2D rb;
    private float moveDirection = 1f;
    private Vector3 targetPosition;
    private Coroutine randomMovementCoroutine;
    [SerializeField] private Transform playerTransform;

    private AnimationController animationController;

    public void Start()
    {
        spriteFlipper = GetComponent<SpriteFlipper>();
        rb = GetComponent<Rigidbody2D>();

        if (playerTransform == null)
        {
            Debug.LogError("Player not found! Make sure the Player has tag 'Player'");
        }

        randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
        animationController = GetComponent<AnimationController>();
    }

    public IEnumerator RandomMovementRoutine()
    {
        while (true)
        {
            moveDirection = Random.value > 0.5f ? 1f : -1f;
            spriteFlipper.SetFlipDirection(-moveDirection);

            isMoving = true;
            float movingTime = Random.Range(minMoveTime, maxMoveTime);
            yield return new WaitForSeconds(movingTime);

            isMoving = false;
            float stopMovingTime = Random.Range(minMoveTime, maxMoveTime);
            yield return new WaitForSeconds(stopMovingTime);
        }
    }

    public void MoveToTarget(Transform player)
    {
        if (isMovingToTarget || isAttacking) return;

        StopCoroutine(randomMovementCoroutine);
        playerTransform = player;
        isMovingToTarget = true;
    }

    public void ReturnToRandomMovement()
    {
        if (!isMovingToTarget || isAttacking) return;

        isMovingToTarget = false;
        randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
    }

    public void ChangeMoveDirection()
    {
        if (transform.position.x <= -8 && moveDirection < 0)
        {
            moveDirection = 1;
        }
        else if (transform.position.x >= 8 && moveDirection > 0)
        {
            moveDirection = -1;
        }
        spriteFlipper.SetFlipDirection(-moveDirection);
    }

    public IEnumerator StopAfterAttackRoutine()
    {
        isAttacking = true;

        isMovingToTarget = false;
        isMoving = false;
        rb.linearVelocityX = 0;
        animationController.SetRunAnimation(0);

        yield return new WaitForSeconds(0.8f);

        DetectPlayerWithRaycast();

        if (playerDetected)
        {
            MoveToTarget(playerTransform);
        }
        else
        {
            ReturnToRandomMovement();
        }

        isAttacking = false;
    }

    public void AfterAttack()
    {
        if (!isAttacking)
        {
            StartCoroutine(StopAfterAttackRoutine());
        }
    }

    public void CustomUpdate()
    {
        DetectPlayerWithRaycast();
        ChangeMoveDirection(); 

        if (isMovingToTarget && playerTransform != null)
        {
            targetPosition = playerTransform.position;

            if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                Vector2 direction = ((Vector2)targetPosition - (Vector2)transform.position).normalized;
                rb.linearVelocityX = direction.x * speed * 3f;
                moveDirection = Mathf.Sign(direction.x);

                spriteFlipper.SetFlipDirection(-moveDirection);
                animationController.SetRunAnimation(Mathf.Abs(direction.x));
            }
            else
            {
                rb.linearVelocityX = 0;
                isMovingToTarget = false;
                animationController.SetRunAnimation(0);
            }
        }
        else if (isMoving)
        {
            rb.linearVelocityX = moveDirection * speed;
            animationController.SetRunAnimation(Mathf.Abs(moveDirection));
        }
        else
        {
            rb.linearVelocityX = 0;
            animationController.SetRunAnimation(0);
        }
    }

    private void DetectPlayerWithRaycast()
    {
        if (playerTransform == null) return;

        LayerMask playerLayerMask = LayerMask.GetMask("Player");

        Vector2 origin = (Vector2)transform.position;
        Vector2 originUp = origin + new Vector2(0f, 0.8f);

        Vector2 directionRight = Vector2.right;
        Vector2 directionLeft = Vector2.left;

        RaycastHit2D hitRight = Physics2D.Raycast(origin, directionRight, detectionRange, playerLayerMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(origin, directionLeft, detectionRange, playerLayerMask);
        RaycastHit2D hitRightUp = Physics2D.Raycast(originUp, directionRight, detectionRange, playerLayerMask);
        RaycastHit2D hitLeftUp = Physics2D.Raycast(originUp, directionLeft, detectionRange, playerLayerMask);




        Color rayColorRight = Color.yellow;
        Color rayColorLeft = Color.yellow;
        Color rayColorRightUp = Color.yellow;
        Color rayColorLeftUp = Color.yellow;

        bool playerDetected = false;

        if (hitRight.collider != null || hitLeft.collider != null || hitRightUp.collider != null || hitLeftUp.collider != null)
        {
            playerDetected = true;
        }

        // Меняем цвет только тех лучей, которые попали в игрока
        if (hitRight.collider != null)
        {
            rayColorRight = Color.red;
        }

        if (hitLeft.collider != null)
        {
            rayColorLeft = Color.red;
        }

        if (hitRightUp.collider != null)
        {
            rayColorRightUp = Color.red;
        }

        if (hitLeftUp.collider != null)
        {
            rayColorLeftUp = Color.red;
        }

        //Debug.DrawRay(origin, directionRight * detectionRange, rayColorRight);
        if (playerDetected)
        {
            if (!isMovingToTarget && !isAttacking)
            {
                MoveToTarget(playerTransform);
            }
        }
        else
        {
            if (isMovingToTarget && !isAttacking)
            {
                ReturnToRandomMovement();
            }
        }
    }

    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.Unregister(this);
    }
}