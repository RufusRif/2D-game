using UnityEngine;

public class PushRigidBody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 sideToBePushed;
    [SerializeField] private float pushForce;

    public void Push()
    {
        rb.AddForce(sideToBePushed * pushForce, ForceMode2D.Impulse);
    }
}
