using UnityEngine;
using UnityEngine.Events;

public class CollisionCheckerPlatform : MonoBehaviour
{
    public UnityEvent OnTouchedFromBelow;  // Срабатывает при касании снизу (OnCollisionEnter2D)
    [SerializeField] private Collider2D currentCollider; // Коллайдер этой панели
    private float heightOfSecondPlatform = 0f;

    private GameObject player;

    void Start()
    {
        // Проверяем, чтобы синглтон был доступен
        if (PlayerState.Instance == null)
        {
            Debug.LogError("PlayerState не найден!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            Vector3 playerPosition = collision.transform.position;
            float panelTopY = currentCollider.bounds.center.y;

            // Если игрок ниже панели
            if (playerPosition.y < panelTopY)
            {
                
                OnTouchedFromBelow.Invoke(); // Вызываем событие
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        // Проверяем, что касается персонаж
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform characterTransform = collision.transform;
            if (currentCollider == null) return;

            float platformCenterY = currentCollider.bounds.center.y;
            float characterY = characterTransform.position.y;

            // Определяем состояние "висит" или "стоит"
            bool isHanging = characterY < platformCenterY;
            bool isStandingOnPlatform = characterY >= platformCenterY;
            //Debug.Log($"characterY: {characterY}, heightOfSecondPlatform: {heightOfSecondPlatform}");

            PlayerState.Instance.SetHangingState(isHanging);
            PlayerState.Instance.SetStandingOnPlatform(isStandingOnPlatform);

            // Определяем, стоит ли персонаж на второй платформе
            bool isOnSecondPlatform = characterY > heightOfSecondPlatform;
            
            PlayerState.Instance.SetStandingOnSecondPlatform(isOnSecondPlatform);
           
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // Если персонаж перестает касаться панели, сбрасываем состояние
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState.Instance.SetHangingState(false);
            PlayerState.Instance.SetStandingOnPlatform(false);
        }
    }
}


