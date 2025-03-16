using UnityEngine;

public class AnimationController : MonoBehaviour, IUpdatable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;


    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.Unregister(this);
    }

    public void CustomUpdate()
    {

        animator.SetFloat("yVelocity", rb.linearVelocityY);


        if (Mathf.Approximately(rb.linearVelocityY, 0))
        {
            animator.SetBool("isJumping", false);
        }
    }
    public void PlayJumpAnimation()
    {
        animator.SetBool("isJumping", true);
    }
}
