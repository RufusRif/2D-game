using UnityEngine;
using UnityEngine.Events;

public class CollisionCheckerPlatform : MonoBehaviour
{
    [SerializeField] private Collider2D currentCollider; // Коллайдер этой панели

    public UnityEvent OnTouchedFromBelow;
    public UnityEvent OnFruitOnRoof;/////////////////////////////////////////////////////////////////////////////////

    private float heightOfSecondPlatform = 0f;


    void Start()
    {
        if (PlayerState.Instance == null)
        {
            Debug.LogError("PlayerState не найден!");
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
        else if (collision.gameObject.CompareTag("Fruit"))
        {
            OnFruitOnRoof?.Invoke();/////////////////////////////////////////////////////////////////////////////////
            Debug.Log("Событие сработало. Фрукт на крыше.");
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

            
            bool isOnSecondPlatform = characterY > heightOfSecondPlatform;
            
            PlayerState.Instance.SetStandingOnSecondPlatform(isOnSecondPlatform);
           
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


