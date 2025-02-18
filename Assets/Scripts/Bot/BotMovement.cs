using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotMovement : MonoBehaviour, IUpdatable
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float minMoveTime = 1f;
    [SerializeField] private float maxMoveTime = 3f;
    [SerializeField] private float minStopTime = 2f;
    [SerializeField] private float maxStopTime = 5f;

    private float moveDirection;
    private Rigidbody2D rb;
    public bool isMoving = true;
    public bool isMovingToTarget = false;

    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private Transform spawnPoint;
    private Vector3 targetPosition;
    private Animator animator;

    [SerializeField] private SpriteFlipper spriteFlipper;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    public IEnumerator RandomMovementRoutine()
    {
        while (true)
        {
            
            moveDirection = Random.value > 0.5f ? 1f : -1f;
            
            spriteFlipper.SetFlipDirection(moveDirection);
           
            float moveTime = Random.Range(minMoveTime, maxMoveTime);
            isMoving = true;
            yield return new WaitForSeconds(moveTime);

            
            isMoving = false;
            float stopTime = Random.Range(minStopTime, maxStopTime);
            yield return new WaitForSeconds(stopTime);
        }
    }

    private void ChangeMoveDirection()
    {
       
        if (transform.position.x <= -8.4 && moveDirection < 0)
        {
            moveDirection = 1;
        }
        else if (transform.position.x >= 8.4 && moveDirection > 0)
        {
            moveDirection = -1;
        }

        spriteFlipper.SetFlipDirection(moveDirection);
    }

    public void MoveToTarget(Vector3 position)
    {
        targetPosition = position;
        isMovingToTarget = true;
    }

    public void CustomUpdate()
    {
        ChangeMoveDirection();
        if (isMovingToTarget)
        {
           
            if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                Vector2 direction = (targetPosition - transform.position).normalized;
                rb.linearVelocityX =direction.x * speed * 2f; 
                moveDirection = Mathf.Sign(direction.x);

                spriteFlipper.SetFlipDirection(moveDirection);

                animator.SetFloat("xVelocity", Mathf.Abs(direction.x));
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

            animator.SetFloat("xVelocity", Mathf.Abs(moveDirection));
        }
        else
        {
            rb.linearVelocityX = 0;

            animator.SetFloat("xVelocity", 0);
        }

        spriteFlipper.SetFlipDirection(moveDirection);
    }

    public IEnumerator DropStonesRoutine()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(stonePrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
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