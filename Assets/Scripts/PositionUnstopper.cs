using UnityEngine;

public class PositionUnstopper : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void UnStopPossition()
    {
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}