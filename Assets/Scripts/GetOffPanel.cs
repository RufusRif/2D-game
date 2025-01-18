using UnityEngine;

public class GetOffPanel : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void JumpDownFromPanel()
    {
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
