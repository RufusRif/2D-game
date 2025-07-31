using UnityEngine;
using UnityEngine.Events;

public class CheckerCollisions : MonoBehaviour
{

    [SerializeField] private string nameOfCollisionOnbect;

    public UnityEvent<GameObject> OnCollisionEnterEvent;
    public UnityEvent OnCollisionStayEvent;
    public UnityEvent OnCollisionExitEvent;

    public UnityEvent<Vector3> OnExplosionNeeded;

    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent<Transform> OnTriggerEnterWithTransform;
    public UnityEvent OnTriggerExitEvent;

    [SerializeField] private bool isInZone;

    //public bool Isinzone {  get; private set; }
    public bool IsInZone
    {
        get { return isInZone; }
        set { isInZone = value; }
    }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameOfCollisionOnbect))
        {
            OnTriggerEnterEvent?.Invoke();
            OnTriggerEnterWithTransform?.Invoke(collision.transform);
            isInZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameOfCollisionOnbect))
        {
            OnTriggerExitEvent?.Invoke();
            isInZone = false;
        }
            
    }
    public void SubscribeToCollisionEvent(UnityAction<GameObject> action)
    {
        OnCollisionEnterEvent.AddListener(action);
    }
}




