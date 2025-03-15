using System.Collections;
using UnityEngine;
public class BotManager : MonoBehaviour
{
    [SerializeField] private BotMovement botMovement;
    private void Start()
    {

        if (botMovement == null)
        {
            botMovement = GetComponent<BotMovement>();
        }

        StartRandomMovement();
    }
    public void StartRandomMovement()
    {
        if (botMovement != null)
        {
            botMovement.isMovingToTarget = false;
            botMovement.isMoving = true;
            StartCoroutine(botMovement.RandomMovementRoutine());
        }
        
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