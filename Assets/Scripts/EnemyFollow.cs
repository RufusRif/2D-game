using UnityEngine;

public class EnemyFollow : MonoBehaviour, IUpdatable
{
    [SerializeField] float speed;
    [SerializeField] Transform player;
   public void CustomUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.Unregister(this);
    }
}
