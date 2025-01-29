using UnityEngine;

public class MoverRigidBodyRightLeft : MonoBehaviour, IUpdatable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveInput;
    [SerializeField] public float speed = 5f;

    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }
    private void OnDisable()
    {
        UpdateManager.Instance.Unregister(this);
    }
    public void MoveHorizontal(float direction)
    {
        moveInput = direction;
    }
    public void CustomUpdate()
    {
        rb.linearVelocityX = moveInput * speed;
    }
}
