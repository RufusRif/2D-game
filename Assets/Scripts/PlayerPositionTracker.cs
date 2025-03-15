using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPositionTracker : MonoBehaviour, IUpdatable
{
    public UnityEvent OnPlayerEnteredZone;
    public UnityEvent OnPlayerExitedZone;
    private float zoneY = -2f;
    [SerializeField] private bool isInZone;
    [SerializeField] Transform playerTransform;

    public void CustomUpdate()
    {
        if (playerTransform.position.y < zoneY)
        {
            if (isInZone == false)
            {
                isInZone = true;
                OnPlayerEnteredZone?.Invoke();
            }
            
        }
        else
        {
            if (isInZone)
            {
                isInZone = false;
                OnPlayerExitedZone?.Invoke();
            }
        }
    }


    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }
    private void OnDisable()
    {
        UpdateManager.Instance.Unregister(this);
    }

}
