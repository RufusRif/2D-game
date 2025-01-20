using System.Collections;
using UnityEngine;

public class JumpOntoPanel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;

    [SerializeField] private string DontInteractWithPanel = "NOCollidePanel";

    private int originalLayer;

    
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        
    }

    public void JumpUpToPanel()
    {
        if (PlayerState.Instance.IsHanging) // Используем состояние из CollisionChecker
        {
            // Сохранить текущий слой
            originalLayer = gameObject.layer;

            // Переключить слой
            gameObject.layer = LayerMask.NameToLayer(DontInteractWithPanel);

            // Применить толчок вверх
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            rb.gravityScale = 1;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            // Вернуть слой через небольшой промежуток времени
            StartCoroutine(RestoreLayerAfterDelay(0.5f));
        }
    }

    private IEnumerator RestoreLayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.layer = originalLayer;
    }
}