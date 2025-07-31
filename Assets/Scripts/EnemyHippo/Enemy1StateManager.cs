using UnityEngine;

public class Enemy1StateManager : MonoBehaviour
{
    public enum Enemy1State
    {
        Idle,
        RandomMovement,
        MovingToTarget,
        Attack
    }
    public Enemy1State enemy1State;
    
    public void SetState(Enemy1State newState)
    {
        
        enemy1State = newState;
    }
}