using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; private set; }
    [field: SerializeField] public bool IsStandingOnSecondPlatform { get; private set; }
    [field: SerializeField] public bool IsStandingOnPlatform { get; private set; }
    [field: SerializeField] public bool IsHanging { get; private set; }
    [field: SerializeField] public bool IsNearTheTree { get; private set; }
    [field: SerializeField] public bool IsOnGround { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        
    }
    
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
    public void SetIsNearTheTree(bool isNearTheTree)
    {
       IsNearTheTree = isNearTheTree;
    }
    public void SetStandingOnSecondPlatform(bool isStandingOnSecondPlatform)
    {
       IsStandingOnSecondPlatform = isStandingOnSecondPlatform;
    }
}




