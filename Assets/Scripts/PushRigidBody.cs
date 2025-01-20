using UnityEngine;

public class PushRigidBody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 sideToBePushed;
    [SerializeField] private float pushForce;

    

    
    public void Push()
    {
        if (PlayerState.Instance.IsOnGround || PlayerState.Instance.IsStandingOnPlatform)
        {
            rb.AddForce(sideToBePushed * pushForce, ForceMode2D.Impulse);
            Debug.Log("Персонаж стоит на земле или на платформе он ПРЫГНЕТ");
        }
        else
        {
            Debug.Log("Персонаж не стоит на земле или платформе, он НЕ ПРЫГНЕТ");
        }
    }
}
