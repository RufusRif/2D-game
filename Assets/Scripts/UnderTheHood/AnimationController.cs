using UnityEngine;

public class AnimationController : MonoBehaviour,IUpdatable
{
    [SerializeField] private Rigidbody2D rb;
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

    public void CustomUpdate()
    {
        
        float xVelocity = Mathf.Abs(rb.linearVelocityX);
        animator.SetFloat("xVelocity", xVelocity);


        float yVelocity = rb.linearVelocityY;
        animator.SetFloat("yVelocity", yVelocity);

        // Обновляем параметр isHanging
        animator.SetBool("isHanging", playerState.IsHanging);

        // Если персонаж находится на земле и вертикальная скорость равна 0
        if (playerState.IsOnGround && Mathf.Approximately(yVelocity, 0))
        {
            animator.SetBool("isJumping", false); // Деактивируем isJumping
        }
    }
}
