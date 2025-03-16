using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;


public class Enemy1Behavior : MonoBehaviour, IUpdatable
{

    [SerializeField] SpriteFlipper spriteFlipper;


    [SerializeField] float speed = 3f;
    [SerializeField] float minMoveTime = 2;
    [SerializeField] float maxMoveTime = 5;
    private bool isMoving = true;
    private Rigidbody2D rb;
    private float moveDirection;
    private Vector3 targetPosition;
    private bool isMovingToTarget = false;
    private Coroutine randomMovementCoroutine;
    private Transform playerTransform;
    private Animator animator;




    public void Start()
    {
        spriteFlipper = GetComponent<SpriteFlipper>();
        rb = GetComponent<Rigidbody2D>();
        randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
        animator = GetComponent<Animator>();
    }

    public IEnumerator RandomMovementRoutine()
    {

        while (true)
        {
            moveDirection = Random.value > 0.5f ? 1f : -1f;
            spriteFlipper.SetFlipDirection(moveDirection);

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
        StopCoroutine(randomMovementCoroutine);
        playerTransform = player;
        isMovingToTarget = true;
    }

    public void ReturtToCorutine()
    {
        isMovingToTarget = false;
        randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
    }
    public void ChangeMoveDirection()
    {
        if (transform.position.x <= -8.4 && moveDirection == -1)
        {
            moveDirection = 1;
        }
        else if (transform.position.x >= 8.4 && moveDirection == 1)
        {
            moveDirection = -1;
        }
        spriteFlipper.SetFlipDirection(moveDirection);

    }
    public void CustomUpdate()
    {
        ChangeMoveDirection();
        if (isMovingToTarget)
        {
            targetPosition = playerTransform.position;

            if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {

                Vector2 direction = ((Vector2)targetPosition - (Vector2)transform.position).normalized;
                rb.linearVelocityX = direction.x * speed * 2f;
                moveDirection = Mathf.Sign(direction.x);

                spriteFlipper.SetFlipDirection(moveDirection);
                animator.SetFloat("xVelocity", 1);
            }

            else
            {
                rb.linearVelocityX = 0;
                isMovingToTarget = false;
                animator.SetFloat("xVelocity", 0);
            }
        }

        else if (isMoving)
        {
            rb.linearVelocityX = moveDirection * speed;
            animator.SetFloat("xVelocity", 1);
        }
        else
        {
            rb.linearVelocityX = 0;
            animator.SetFloat("xVelocity", 0);
        }
        spriteFlipper.SetFlipDirection(-moveDirection);

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