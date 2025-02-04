using UnityEngine;
using UnityEngine.EventSystems;

public class MoverRigidBodyRightLeft : MonoBehaviour, IUpdatable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveInput;
    [SerializeField] public float speed = 5f;


    [SerializeField] private SpriteFlipper spriteFlipper;


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
        spriteFlipper.SetFlipDirection(direction);
    }
    public void CustomUpdate()
    {
        rb.linearVelocityX = moveInput * speed;
        
       
    }
}
