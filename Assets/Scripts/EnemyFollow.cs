using UnityEngine;

public class EnemyFollow : MonoBehaviour, IUpdatable
{
    [SerializeField] float speed;
    [SerializeField] Transform player;
    public void CustomUpdate()
    {

        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, player.transform.position.x, speed * Time.deltaTime), transform.position.y);
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
