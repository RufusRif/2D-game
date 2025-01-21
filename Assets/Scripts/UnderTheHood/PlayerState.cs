using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; private set; }

    public bool IsHanging { get; private set; }
    public bool IsStandingOnPlatform {  get; private set; }

    public bool IsOnGround {  get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Установка состояния: висит/не висит
    public void SetHangingState(bool isHanging)
    {
        IsHanging = isHanging;
    }

    public void SetStandingOnPlatform(bool isStandingOnPlatform)
    {
        IsStandingOnPlatform = isStandingOnPlatform;
    }

    public void SetOnGround(bool isOnGround)
    {
        IsOnGround = isOnGround;
    }

}




