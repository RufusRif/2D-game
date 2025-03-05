using UnityEngine;

public class RotaterObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 200;

    private void Start()
    {
        // Устанавливаем постоянную угловую скорость
        rb.angularVelocity = rotationSpeed;
    }

}
