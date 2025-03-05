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


    public void PushDynamite()
    {
        Vector2 direction = playerScale.localScale.x > 0 ? Vector2.right : Vector2.left;
        rbDynamite.AddForce(direction * pushForce, ForceMode2D.Impulse);
    }

}
