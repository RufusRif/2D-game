using UnityEngine;

public class FixedAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f; 
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Фиксируем высоту, подстраиваем ширину
        cam.aspect = targetAspect;
    }
}
