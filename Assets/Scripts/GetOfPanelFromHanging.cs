using UnityEngine;

public class GetOfPanelFromHanging : MonoBehaviour
{
    //private PlayerState playerState;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    public void JumpDownFromPanel()
    {
        if (PlayerState.Instance.IsHanging)
        {
            rb.gravityScale = 1;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
