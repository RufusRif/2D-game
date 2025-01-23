using UnityEngine;

public class NutState : MonoBehaviour
{
    public static NutState Instance { get; private set; }


    public bool IsTaiking { get; private set; }

    public void SetIsTaking(bool isTaking)
    {
        IsTaiking = isTaking;
    }

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

}
