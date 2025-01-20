using UnityEngine;
using System.Collections;

public class GetOfPanelFromStandingPosition : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private string DontInteractWithPanel = "NOCollidePanel";

    private int originalLayer;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalLayer = gameObject.layer;

    }
    public void JumpDown()
    {
        if (PlayerState.Instance.IsStandingOnPlatform && gameObject.layer == originalLayer)
        {
            // Сохранить текущий слой
            originalLayer = gameObject.layer;

            // Переключить слой
            gameObject.layer = LayerMask.NameToLayer(DontInteractWithPanel);
            StartCoroutine(RestoreLayerAfterDelay(0.5f));
        }
    }
    private IEnumerator RestoreLayerAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        gameObject.layer = originalLayer;

    }
}
