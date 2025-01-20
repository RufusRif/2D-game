using UnityEngine;
using UnityEngine.Events;

public class CollisionCheckerPlatform : MonoBehaviour
{
    public UnityEvent OnTouchedFromBelow;  // Срабатывает при касании снизу (OnCollisionEnter2D)
    [SerializeField] private Collider2D currentCollider; // Коллайдер этой панели
    
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

                //Debug.Log($"Игрок коснулся панели снизу.isHanGGGing = " + isHanging);
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

            // Если персонаж ниже панели, он висит
            if (characterTransform.position.y < currentCollider.bounds.center.y)
            {
                PlayerState.Instance.SetHangingState(true);
                PlayerState.Instance.SetStandingOnPlatform(false);
            }
            else
            {
                PlayerState.Instance.SetHangingState(false);
                PlayerState.Instance.SetStandingOnPlatform(true);
            }
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


