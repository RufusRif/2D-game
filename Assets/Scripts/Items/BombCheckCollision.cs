using UnityEngine;
using UnityEngine.Events;

public class BombCheckCollision : MonoBehaviour
{
    [SerializeField] private string nameOfTag;
    public UnityEvent CaughtTheBomb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameOfTag))
        {
            CaughtTheBomb?.Invoke();
            Destroy(collision.gameObject);
        }
    }
    
}
