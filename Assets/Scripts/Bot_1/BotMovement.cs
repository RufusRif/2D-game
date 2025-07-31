using System.Collections;
using TMPro;
using UnityEngine;

public class BotMovement : MonoBehaviour, IUpdatable
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float minMoveTime = 1f;
    [SerializeField] private float maxMoveTime = 3f;
    [SerializeField] private float minStopTime = 2f;
    [SerializeField] private float maxStopTime = 5f;
    [SerializeField] private SpriteFlipper spriteFlipper;
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private Transform spawnPoint;

    private float moveDirection;
    private Vector3 targetPosition;

    private Rigidbody2D rb;
    private AnimationController animationController;
    private BotStateManager botStateManager;

    private Coroutine randomMovementCoroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
        botStateManager = GetComponent<BotStateManager>();
    }
    private void Start()
    {
        randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
    }
    public void StartRandomMovementCoroutine()
    {
        randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
    }

    public IEnumerator RandomMovementRoutine()
    {
        while (true)
        {
           
            if (botStateManager.botState == BotStateManager.BotState.RandomMovement)
            {
                moveDirection = Random.value > 0.5f ? 1f : -1f;
                spriteFlipper.SetFlipDirection(moveDirection);

                float moveTime = Random.Range(minMoveTime, maxMoveTime);
                yield return new WaitForSeconds(moveTime);

                botStateManager.SetState(BotStateManager.BotState.Idle);
                float stopTime = Random.Range(minStopTime, maxStopTime);
                yield return new WaitForSeconds(stopTime);


                if (botStateManager.botState != BotStateManager.BotState.MovingToTarget)
                {
                    botStateManager.SetState(BotStateManager.BotState.RandomMovement);
                }
            }
            else
            {
                yield return null;
            }
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

    public void MoveToTarget(GameObject position)
    {
        targetPosition = position.transform.position;
        StopCoroutine(randomMovementCoroutine);
        botStateManager.SetState(BotStateManager.BotState.MovingToTarget);
    }
    private void HandleMovingToTarget()
    {
        Vector2 direction = (targetPosition - transform.position).normalized;
        rb.linearVelocityX = direction.x * speed * 2f;
        moveDirection = Mathf.Sign(direction.x);
        spriteFlipper.SetFlipDirection(moveDirection);
        animationController.SetRunAnimation(Mathf.Abs(direction.x));
    }
    private void HandleRandomMovement()
    {
        rb.linearVelocityX = moveDirection * speed;
        animationController.SetRunAnimation(Mathf.Abs(moveDirection));
    }
    private void HandleIdle()
    {
        rb.linearVelocityX = 0;
        animationController.SetRunAnimation(0);
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
    public void CustomUpdate()
    {
        ChangeMoveDirection();

        switch (botStateManager.botState)
        {
            case BotStateManager.BotState.MovingToTarget:

                HandleMovingToTarget(); break;

            case BotStateManager.BotState.RandomMovement:
                HandleRandomMovement(); break;

            case BotStateManager.BotState.Idle:
                HandleIdle(); break;

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