//using UnityEngine;

//public class DebugCheck : MonoBehaviour
//{
//    [SerializeField] private Collider2D currentCollider; // Коллайдер этой панели
//    private CharacterState characterState; // Состояние персонажа

//    void Start()
//    {
//        // Находим состояние персонажа в сцене
//        characterState = FindObjectOfType<CharacterState>();
//    }

//    void OnCollisionStay2D(Collision2D collision)
//    {
//        // Проверяем, что касается персонаж
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            Transform characterTransform = collision.transform;

//            // Если персонаж ниже панели, он висит
//            if (characterTransform.position.y < currentCollider.bounds.center.y)
//            {
//                characterState.SetHangingState(true);
//            }
//            else
//            {
//                characterState.SetHangingState(false);
//            }
//        }
//    }

//    void OnCollisionExit2D(Collision2D collision)
//    {
//        // Если персонаж перестает касаться панели, сбрасываем состояние
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            characterState.SetHangingState(false);
//        }
//    }
//}
