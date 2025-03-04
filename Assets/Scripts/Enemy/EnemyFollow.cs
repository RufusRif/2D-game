using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform player;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
