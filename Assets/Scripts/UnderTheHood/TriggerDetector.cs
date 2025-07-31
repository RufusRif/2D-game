using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector : MonoBehaviour
{
    public UltEventst<Transform> onPlayerDetectedByRays;
    public UnityEvent onPlayerLostFromRays;
}
