using System.Collections;
using UnityEngine;

public class JumpOntoPanel : MonoBehaviour
{
    
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;

    private int originalLayer;
    [SerializeField] private string noClimbLayerName = "NOCollidePanel";

    public void JumpUpToPanel()
    {
        // Сохранить текущий слой
        originalLayer = gameObject.layer;

        // Переключить слой
        gameObject.layer = LayerMask.NameToLayer(noClimbLayerName);

        // Применить толчок вверх
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);

        // Вернуть слой через 1 секунду
        StartCoroutine(RestoreLayerAfterDelay(1f));
    }
    private IEnumerator RestoreLayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.layer = originalLayer;
    }
}
