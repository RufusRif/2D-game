using UnityEngine;
using UnityEngine.Events;

public class CheckerCollisions : MonoBehaviour
{
    [SerializeField] private PlayerState playerState;
    [SerializeField] private string nameOfCollisionOnject;
    public UnityEvent OnCollisionStayEvent;
    public UnityEvent OnCollisionExitEvent;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(nameOfCollisionOnject))
        {
            OnCollisionStayEvent?.Invoke();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(nameOfCollisionOnject))
        {
           OnCollisionExitEvent?.Invoke();
        }
    }
}




//public class CheckerGroung : MonoBehaviour
//{
//    [SerializeField] private PlayerState playerState;

//    private void OnCollisionStay2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            playerState.SetOnGround(true);
//        }
//    }
//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            playerState.SetOnGround(false);
//        }
//    }
//}