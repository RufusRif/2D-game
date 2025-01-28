//using System.Collections;
//using UnityEngine;
//using UnityEngine.Events;

//public class Training : MonoBehaviour
//{
//    public UnityEvent OnTouchedFromBelow;

//    public UnityEvent OnFruitOnRoof;
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            Vector3 playerPosition = collision.gameObject.transform.position;
//            float positionYOfPanel = transform.position.y;

//            if (playerPosition.y < positionYOfPanel)
//            {
//                OnTouchedFromBelow?.Invoke();
//            }
//        }
//        else if (collision.gameObject.CompareTag("Fruit"))
//        {
//            OnFruitOnRoof?.Invoke();
//        }
//    }
//}



