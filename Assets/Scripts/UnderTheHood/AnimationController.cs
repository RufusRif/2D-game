using UnityEngine;

public class AnimationController : MonoBehaviour, IUpdatable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetRunAnimation(float velocity)
    {
        if (HasAnimatorParameter("xVelocity", AnimatorControllerParameterType.Float))
        {
            animator.SetFloat("xVelocity", Mathf.Abs(velocity));
        }
    }
    public void PlayJumpAnimation()
    {
        if (HasAnimatorParameter("isJumping", AnimatorControllerParameterType.Bool))
        {
            animator.SetBool("isJumping", true);
        }     
    }
    public void StopJumpAnimation()
    {
        if (HasAnimatorParameter("isJumping", AnimatorControllerParameterType.Bool))
        {
            animator.SetBool("isJumping", false);
        }  
    }
    public void HitPlayerAnimation()
    {
        animator.SetTrigger("HitTrigger");
    }
    
    public void UpdateMovementAnimations()
    {
        if(HasAnimatorParameter("yVelocity",AnimatorControllerParameterType.Float))
        {
            float yVelocity = rb.linearVelocityY;

            {
                animator.SetFloat("yVelocity", yVelocity);

                if (Mathf.Approximately(yVelocity, 0))
                {
                    StopJumpAnimation();
                }
            }
        }
       
           
    }
    private bool HasAnimatorParameter(string parameterName, AnimatorControllerParameterType parameterType)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == parameterName && parameter.type == parameterType)
            {
                return true;
            }
        }
        return false;
    }
    public void CustomUpdate()
    {
        UpdateMovementAnimations();
    }

    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.Unregister(this);
    }

}
