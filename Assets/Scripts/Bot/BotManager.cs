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
        else
        {
            Debug.LogError("BotMovement is not assigned or found on the object!");
        }
    }

    public void NoticeFruit(Vector3 fruitPosition)
    {
        botMovement.MoveToTarget(fruitPosition);
    }

    public void DropStones()
    {
        StartCoroutine(botMovement.DropStonesRoutine());
        StartRandomMovement();
    }
}