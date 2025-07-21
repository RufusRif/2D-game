using UnityEngine;

public class BotStateManager : MonoBehaviour
{
    public enum BotState
    {
        Idle,
        RandomMovement,
        MovingToTarget
    }
    public BotState botState;

    private void Start()
    {
        botState = BotState.RandomMovement;
    }

    public void SetState(BotState newState)
    {
        botState = newState;
    }


}
