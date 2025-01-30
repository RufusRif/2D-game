using System.Collections;
using UnityEngine;

public class BotMovement : MonoBehaviour, IUpdatable
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float minMoveTime = 2f;
    [SerializeField] private float maxMoveTime = 5f;
    [SerializeField] private float minStopTime = 1f;
    [SerializeField] private float maxStopTime = 3f;
    private float moveDirection;

    private Rigidbody2D rb;
    private bool isMoving = true;

    [SerializeField] private GameObject stonePrefab;//
    [SerializeField] private Transform spawnPoint;//
    private bool isMovingToTarget = false; // Флаг: движение к цели
    private Vector3 targetPosition;        // Целевая позиция


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(MoveRoutine());
        StartRandomMovement();
    }
    public void StartRandomMovement()
    {
        isMovingToTarget = false; // Отключаем движение к цели
        StartCoroutine(RandomMovementRoutine());
    }
    private IEnumerator RandomMovementRoutine()
    {
        while (true)
        {
            moveDirection = Random.value > 0.5f ? 1f : -1f;  // < переменная > = < условие > ? < значение_если_истина > : < значение_если_ложь >;

            float moveTime = Random.Range(minMoveTime, maxMoveTime);
            isMoving = true;

            yield return new WaitForSeconds(moveTime);

            isMoving = false;

            // Устанавливаем случайное время остановки
            float stopTime = Random.Range(minStopTime, maxStopTime);
            yield return new WaitForSeconds(stopTime);
        }
    }
    public void MoveToPosition(Vector3 position)
    {
        StopCurrentRoutine();
        targetPosition = position;
        
        isMovingToTarget = true; // Включаем движение к цели
    }
    private void MoveTowardsTarget()
    {
        if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            Vector2 direction = (targetPosition - transform.position).normalized;
            rb.linearVelocityX = direction.x * speed;
            
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Останавливаем движение
            isMovingToTarget = false;  // Выключаем флаг
            StartCoroutine(DropStonesRoutine()); // Запускаем сброс камней
        }
    }
    private void StopCurrentRoutine()
    {
        StopAllCoroutines();
        rb.linearVelocity = Vector2.zero; // Останавливаем движение
    }

    
    private IEnumerator DropStonesRoutine()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log($"Создан камень {i + 1}");
            Instantiate(stonePrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }

        StartRandomMovement(); // Возвращаемся к случайным движениям
    }
    public void CustomUpdate()
    {

        if (isMoving)
        {
            rb.linearVelocityX = moveDirection * speed;
        }
        else
        {
            rb.linearVelocityX = 0f;
        }

        if (isMovingToTarget)
        {
            MoveTowardsTarget();
        }
        ChangeMoveDirection();
        FlipCharacter();
    }
    private void ChangeMoveDirection()
    {
        if (transform.position.x <= -8.4 && moveDirection < 0)
        {
            moveDirection = 1;

        }
        else if (transform.position.x >= 8.2 && moveDirection > 0)
        {
            moveDirection = -1;

        }
    }
    private void FlipCharacter()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * -moveDirection;

        transform.localScale = scale;
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