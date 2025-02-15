using UnityEngine;

public class PushRigidBody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 sideToBePushed = new Vector2(0,1);
    [SerializeField] private float pushForce = 5;
    public ObjectInstantiater objectInstantiater;
    [SerializeField] Animator animator;

    public void Push()
    {
        rb.AddForce(sideToBePushed * pushForce, ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
    }
}
