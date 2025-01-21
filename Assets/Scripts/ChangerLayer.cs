using System.Collections;
using UnityEngine;

public class ChangerLayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private string DontInteractWithPanel = "NOCollidePanel";
    private int originalLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ChangeTheLayer()
    {
        originalLayer = gameObject.layer; // Сохранить текущий слой
        gameObject.layer = LayerMask.NameToLayer(DontInteractWithPanel);// Переключить слой
        StartCoroutine(RestoreLayerAfterDelay(0.5f));
    }
    private IEnumerator RestoreLayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.layer = originalLayer;
    }
}
