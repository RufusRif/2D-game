using UnityEngine;
using UnityEngine.Events;

public class CollisionCheckerPlatform : MonoBehaviour
{
    [SerializeField] private Collider2D currentCollider; 

    public UnityEvent OnTouchedFromBelow;
  

    private void Start()
    {
        if (ActionDispatcher.Instance != null)
        {
            PositionStopper stopper = ActionDispatcher.Instance.PlayerStopper;
            if (stopper != null)
            {
                // Подписываем StopMovement на событие
                OnTouchedFromBelow.AddListener(stopper.StopMovement);
            }
            else
            {
                Debug.LogWarning("PositionStopper not found on Player!", this);
            }
        }
        else
        {
            Debug.LogError("ActionDispatcher not found! Cannot subscribe to OnTouchedFromBelow.", this);
        }
    }

    private void OnDestroy()
    {
        // ВАЖНО: отписываемся при уничтожении платформы
        if (ActionDispatcher.Instance != null)
        {
            PositionStopper stopper = ActionDispatcher.Instance.PlayerStopper;
            if (stopper != null)
            {
                OnTouchedFromBelow.RemoveListener(stopper.StopMovement);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerPosition = collision.transform.position;
            float panelTopY = currentCollider.bounds.center.y;

            if (playerPosition.y < panelTopY)
            {
                OnTouchedFromBelow?.Invoke();
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform characterTransform = collision.transform;

            float platformCenterY = currentCollider.bounds.center.y;
            float characterY = characterTransform.position.y;


            bool isHanging = characterY < platformCenterY;
            bool isStandingOnPlatform = characterY >= platformCenterY;


            PlayerState.Instance.SetHangingState(isHanging);
            PlayerState.Instance.SetStandingOnPlatform(isStandingOnPlatform);

            
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState.Instance.SetHangingState(false);
            PlayerState.Instance.SetStandingOnPlatform(false);
        }
    }
}
