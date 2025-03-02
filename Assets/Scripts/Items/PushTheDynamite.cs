using UnityEngine;

public class PushTheDynamite : MonoBehaviour
{
    [SerializeField] private Transform playerScale;
    [SerializeField] private Rigidbody2D rbDynamite;
    [SerializeField] private float pushForce = 5;

    public void Initialize(Transform player)
    {
        playerScale = player; // Устанавливаем ссылку на игрока
    }

    //private void Start()
    //{
    //    // Находим игрока по тегу
    //    GameObject playerObject = GameObject.FindWithTag("Player");
    //    if (playerObject != null)
    //    {
    //        playerScale = playerObject.transform;
    //    }
    //    else
    //    {
    //        Debug.LogError("Player not found on the scene!");
    //    }
    //    PushDynamite();
    //}
    public void PushDynamite()
    {
        // Проверяем, что playerScale инициализирован
        if (playerScale == null)
        {
            Debug.LogError("Player reference is missing! Make sure the player is tagged correctly.");
            return;
        }

        if (rbDynamite == null)
        {
            Debug.LogError("Rigidbody reference is missing!");
            return;
        }
        Vector2 direction = playerScale.localScale.x > 0 ? Vector2.right :Vector2.left;
        rbDynamite.AddForce(direction * pushForce, ForceMode2D.Impulse);
    }
   
}
