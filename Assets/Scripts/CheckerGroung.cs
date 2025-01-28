using UnityEngine;

public class CheckerGroung : MonoBehaviour
{
    [SerializeField] private PlayerState playerState;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           playerState.SetOnGround(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerState.SetOnGround(false);
        }
    }
}
