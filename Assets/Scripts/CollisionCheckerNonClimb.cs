using UnityEngine;
using UnityEngine.Events;

public class CollisionCheckerNonClimb : MonoBehaviour
{
    [SerializeField] private Collider2D currentCollider;

    public UnityEvent<GameObject> OnFruitOnFloor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fruit"))
        {
            GameObject fruitPosition = collision.gameObject;
            OnFruitOnFloor?.Invoke(fruitPosition);
        }
    }
}
