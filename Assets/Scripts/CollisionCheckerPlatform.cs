using UnityEngine;
using UnityEngine.Events;

public class CollisionCheckerPlatform : MonoBehaviour
{
    [SerializeField] private Collider2D currentCollider; 

    public UnityEvent OnTouchedFromBelow;
    private float heightOfSecondPlatform = 0f;

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
            if (currentCollider == null) return;

            float platformCenterY = currentCollider.bounds.center.y;
            float characterY = characterTransform.position.y;


            bool isHanging = characterY < platformCenterY;
            bool isStandingOnPlatform = characterY >= platformCenterY;


            PlayerState.Instance.SetHangingState(isHanging);
            PlayerState.Instance.SetStandingOnPlatform(isStandingOnPlatform);


            bool isOnSecondPlatform = isStandingOnPlatform && characterY > heightOfSecondPlatform;

            PlayerState.Instance.SetStandingOnSecondPlatform(isOnSecondPlatform);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState.Instance.SetHangingState(false);
            PlayerState.Instance.SetStandingOnPlatform(false);
            PlayerState.Instance.SetStandingOnSecondPlatform(false);
        }

    }
}
