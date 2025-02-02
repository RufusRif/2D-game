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








//public class BotManager : MonoBehaviour
//{
//    [SerializeField] private BotMovement botMovement;

//    private void Start()
//    {
//        if (botMovement == null)
//        {
//            botMovement = GetComponent<BotMovement>();
//        }
//    }

//    public void NoticedFruitOnFloor(Vector3 position)
//    {
//        botMovement.SetIsMoving(false);
//        StopRandomMovement();
//        StartCoroutine(botMovement.MoveToTarget(position));
//    }

//    public void AteFruit()
//    {
//        StartCoroutine(DropStonesAndResumeMovement());
//    }

//    private IEnumerator DropStonesAndResumeMovement()
//    {
//        yield return botMovement.DropStonesRoutine();

//        botMovement.SetIsMoving(true);
//        botMovement.SetMoveDirection(Random.value > 0.5f ? 1f : -1f);
//        ResumeRandomMovement();
//    }

//    private void StopRandomMovement()
//    {
//        botMovement.SetIsMoving(false);
//    }

//    private void ResumeRandomMovement()
//    {
//        StartCoroutine(botMovement.RandomMovementRoutine());
//    }
//}
