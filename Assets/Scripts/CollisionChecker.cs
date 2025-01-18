using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    

    [Header("Настройки")]
    [Tooltip("Минимальная разница по высоте, чтобы игрок считался ниже планки")]
    public float heightThreshold = 0.1f;

    [Header("События")]
    [Tooltip("Событие срабатывает, если игрок ниже планки")]
    public UnityEvent OnPlayerBelowPlank;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, что объект имеет тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Получаем позиции игрока и планки
            Vector2 playerPosition = collision.transform.position;
            Vector2 plankPosition = transform.position;

            // Проверяем, что игрок ниже планки
            if (playerPosition.y < plankPosition.y - heightThreshold)
            {
                
                // Вызываем событие
                OnPlayerBelowPlank?.Invoke();
            }
        }
    }
}
