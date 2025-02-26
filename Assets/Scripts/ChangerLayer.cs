using System.Collections;
using UnityEngine;

public class ChangerLayer : MonoBehaviour
{
    [SerializeField] private string DontInteractWithPanel = "NOCollidePanel";
    private int originalLayer;
    public void ChangeTheLayer()
    {
        originalLayer = gameObject.layer; 
        gameObject.layer = LayerMask.NameToLayer(DontInteractWithPanel);
        StartCoroutine(RestoreLayerAfterDelay(0.5f));
    }
    private IEnumerator RestoreLayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.layer = originalLayer;
    }
}