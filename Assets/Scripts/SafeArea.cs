using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform rectTransform;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        
    }
    private void Start()
    {
        ApplySafeArea();
    }
    void ApplySafeArea()
    {
        if (Screen.width == 0 || Screen.height == 0)
        {
            Debug.LogWarning("Screen size is zero! Delaying SafeArea setup.");
            Invoke(nameof(ApplySafeArea), 0.1f); 
            return;
        }
        Rect safeArea = Screen.safeArea;

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}
