using UnityEngine;
using UnityEngine.EventSystems;

public class MoverRigidBodyRightLeft : MonoBehaviour, IUpdatable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveInput;
    [SerializeField] public float speed = 5f;

    [SerializeField] private SpriteFlipper spriteFlipper;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerState playerState;

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
        
        UpdateAnimatorParameters();

       
        if (!playerState.IsHanging)
        {
            rb.linearVelocityX = moveInput * speed;
        }
        else
        {
           
            rb.linearVelocityX = 0;
        }
    }

    private void UpdateAnimatorParameters()
    {
        
        animator.SetBool("isHanging", playerState.IsHanging);

        
        if (!playerState.IsHanging)
        {
            if (moveInput != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            
            animator.SetBool("isRunning", false);
        }
    }
}
