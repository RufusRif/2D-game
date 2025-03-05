using UnityEngine;
using UnityEngine.Events;

public class BotCheckCollision : MonoBehaviour
{
    public UnityEvent FruitWasEaten;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            FruitWasEaten?.Invoke();
        }
    }
}
