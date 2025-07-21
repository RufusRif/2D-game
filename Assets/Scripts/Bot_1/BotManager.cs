using System.Collections;
using UnityEngine;
public class BotManager : MonoBehaviour
{
    [SerializeField] private BotMovement botMovement;
    [SerializeField] private BotStateManager botStateManager;

    public void StartRandomMovement()
    {
        botStateManager.SetState(BotStateManager.BotState.RandomMovement);
        botMovement.StartRandomMovementCoroutine();
    }
    public void NoticeFruit(GameObject fruit)
    {
        botMovement.MoveToTarget(fruit);
    }
    public void DropStones()
    {
        StartCoroutine(botMovement.DropStonesRoutine());
        StartRandomMovement();
    }
}