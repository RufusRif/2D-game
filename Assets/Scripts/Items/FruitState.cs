using UnityEngine;
using UnityEngine.Events;

public class FruitState : MonoBehaviour
{
    public static FruitState Instance { get; private set; }
    public bool IsTaiking { get; private set; }

    public UnityEvent OnNutTaken;
    public UnityEvent OnNutDropped;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetIsTaking(bool isTaking)
    {
        if (IsTaiking == isTaking) return;
        IsTaiking = isTaking;

        if(isTaking)
        {
            OnNutTaken?.Invoke();
        }
        else
        {
            OnNutDropped?.Invoke();
        }
    }
}
