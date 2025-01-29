using System.Collections;
using UnityEngine;

public class BotMovement : MonoBehaviour, IUpdatable
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float minMoveTime = 2f;
    [SerializeField] private float maxMoveTime = 5f;
    [SerializeField] private float minStopTime = 1f;
    [SerializeField] private float maxStopTime = 3f;

    private Rigidbody2D rb;
    private bool isMoving = true;

    private float moveDirection;
    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }
    private void OnDisable()
    {
        UpdateManager.Instance.Unregister(this);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
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
   
}