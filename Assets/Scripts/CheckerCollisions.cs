using UnityEngine;
using UnityEngine.Events;

public class CheckerCollisions : MonoBehaviour
{
    
    [SerializeField] private string nameOfCollisionOnbect;
    public UnityEvent OnCollisionStayEvent;
    public UnityEvent OnCollisionExitEvent;
    public UnityEvent<GameObject> OnCollisionEnterEvent;

    public UnityEvent<Vector3> OnExplosionNeeded;

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
            GameObject someObject = collision.gameObject;
            OnCollisionEnterEvent?.Invoke(someObject);

            Vector3 explosionPosition = collision.transform.position;
            OnExplosionNeeded?.Invoke(explosionPosition);
        }
    }
}




