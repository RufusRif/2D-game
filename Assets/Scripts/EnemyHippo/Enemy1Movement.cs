using System.Collections;
using TMPro;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;


public class Enemy1Movement : MonoBehaviour, IUpdatable
{
    [SerializeField] CheckerCollisions checkerCollisions;
    private SpriteFlipper spriteFlipper;
    private Coroutine randomMovementCoroutine;
    private Enemy1StateManager enemy1StateManager;
    private Rigidbody2D rb;
    private AnimationController animationController;

    private Vector3 targetPosition;
    private float moveDirection = 1f;
    private float speed = 2f;
    private float detectionRange = 20f;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float minMoveTime = 2f;
    [SerializeField] private float maxMoveTime = 5f;
    [SerializeField] private float minStopTime = 2f;
    [SerializeField] private float maxStopTime = 5f;
    [SerializeField] private int damage = 1;

    private void Awake()
    {
        enemy1StateManager = GetComponent<Enemy1StateManager>();
        spriteFlipper = GetComponent<SpriteFlipper>();
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
    }
    private void Start()
    {
        randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
    }
    public IEnumerator RandomMovementRoutine()
    {
        while (true)
        {
            if (enemy1StateManager.enemy1State != Enemy1StateManager.Enemy1State.MovingToTarget && enemy1StateManager.enemy1State != Enemy1StateManager.Enemy1State.Attack)
            {
                moveDirection = Random.value > 0.5f ? 1f : -1f;
                spriteFlipper.SetFlipDirection(-moveDirection);

                float movingTime = Random.Range(minMoveTime, maxMoveTime);
                yield return new WaitForSeconds(movingTime);

                if (enemy1StateManager.enemy1State != Enemy1StateManager.Enemy1State.MovingToTarget && enemy1StateManager.enemy1State != Enemy1StateManager.Enemy1State.Attack)
                {
                    enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.Idle);
                }
                float stopTime = Random.Range(minStopTime, maxStopTime);
                yield return new WaitForSeconds(stopTime);

                if (enemy1StateManager.enemy1State == Enemy1StateManager.Enemy1State.Idle)
                {
                    enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.RandomMovement);
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    public IEnumerator AttackPauseRoutine()
    {
        enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.Idle);
        yield return new WaitForSeconds(0.8f);

        if(checkerCollisions.IsInZone)
        {
            enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.MovingToTarget);
        }
        else
        {
            enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.RandomMovement);
        }


    }
    private void HandleIdle()
    {
        rb.linearVelocityX = 0;
        animationController.SetRunAnimation(0);
    }
    private void HandleRandomMovement()
    {
        rb.linearVelocityX = moveDirection * speed;
        animationController.SetRunAnimation(Mathf.Abs(moveDirection));
    }
    private void HandleMovingToTarget()
    {
        if (playerTransform != null)
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
        }
    }
    private void HandleAttack()
    {
        IDamageable damageable = playerTransform.GetComponentInChildren<IDamageable>();
        if (damageable != null && damageable.IsAlive())
        {
            damageable.TakeDamage(damage);
            SoundManager.Instance.PlaySoundEffect("RhinoAttack");
            
        }
        StartCoroutine(AttackPauseRoutine());
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
    public void CustomUpdate()
    {
        ChangeMoveDirection();
        switch (enemy1StateManager.enemy1State)
        {
            case Enemy1StateManager.Enemy1State.Idle:
                HandleIdle(); break;

            case Enemy1StateManager.Enemy1State.RandomMovement:
                HandleRandomMovement(); break;

            case Enemy1StateManager.Enemy1State.MovingToTarget:
                HandleMovingToTarget(); break;

            case Enemy1StateManager.Enemy1State.Attack:
                HandleAttack(); break;
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
