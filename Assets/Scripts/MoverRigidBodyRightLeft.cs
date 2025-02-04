using UnityEngine;
using UnityEngine.EventSystems;

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
        FlipPlayer();
    }
    private void FlipPlayer()
    {
        Vector3 scale = transform.localScale;
        if (moveInput != 0)
        {
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(moveInput);
        }
        transform.localScale = scale;
    }


}
