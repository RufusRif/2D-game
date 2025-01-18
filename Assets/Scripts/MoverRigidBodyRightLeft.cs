using UnityEngine;

public class MoverRigidBodyRightLeft : MonoBehaviour, IUpdatable
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveInput;

    [SerializeField] public float speed = 5f;

    private void OnEnable()
    {
        // Регистрируем этот объект в UpdateManager
        UpdateManager.Instance.Register(this);
       
    }

    private void OnDisable()
    {
        // Отменяем регистрацию объекта при его уничтожении
        UpdateManager.Instance.Unregister(this);
    }
    public void MoveHorizontal(float direction)
    {
        moveInput = direction;
    }
    public void Update()
    {
       
        rb.linearVelocityX = moveInput * speed;

    }

}
