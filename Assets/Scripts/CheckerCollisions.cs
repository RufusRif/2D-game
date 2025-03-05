using UnityEngine;
using UnityEngine.Events;

public class CheckerCollisions : MonoBehaviour
{
    
    [SerializeField] private string nameOfCollisionOnbect;
    public UnityEvent OnCollisionStayEvent;
    public UnityEvent OnCollisionExitEvent;
    public UnityEvent<GameObject> OnCollisionEnterEvent;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(nameOfCollisionOnbect))
        {
            OnCollisionStayEvent?.Invoke();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(nameOfCollisionOnbect))
        {
            OnCollisionExitEvent?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(nameOfCollisionOnbect))
        {
            Debug.Log("Событие столкновение с яблоком произошло");
            GameObject someObject = collision.gameObject;
            OnCollisionEnterEvent?.Invoke(someObject);
        }
    }
   
}




