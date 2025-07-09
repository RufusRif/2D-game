using UnityEngine;
using UnityEngine.Events;

public class ActionDispatcher : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PushRigidBody pushRigidBody;
    [SerializeField] ChangerLayer changerLayer;
    [SerializeField] PositionUnstopper positionUnstopper;
    [SerializeField] MoverRigidBodyRightLeft moverRigidBody;
    [SerializeField] ObjectInstantiater objectInstantiater;
    [SerializeField] DynamiteSpawner dynamiteSpawner;
    [SerializeField] FruitState fruitState;
    [SerializeField] InventoryPlayer inventoryPlayer;

    [SerializeField] GameObject dynamitePrefab;
    [SerializeField] GameObject applePrefab;



    public void UpButtonPressed()
    {
        if (PlayerState.Instance.IsOnGround || PlayerState.Instance.IsStandingOnPlatform)
        {
            pushRigidBody?.Push();
        }

        else if (PlayerState.Instance.IsHanging)
        {
            changerLayer?.ChangeTheLayer();
            pushRigidBody?.Push();
            positionUnstopper?.UnStopPossition();
        }
    }
    public void DownButtonPressed()
    {
        if (PlayerState.Instance.IsStandingOnPlatform)
        {
            changerLayer?.ChangeTheLayer();
        }
        else if (PlayerState.Instance.IsHanging || (!PlayerState.Instance.IsStandingOnPlatform && !PlayerState.Instance.IsHanging))
        {
            positionUnstopper?.UnStopPossition();
        }
        
    }
    public void MoveButtonPressed(float direction)
    {
        moverRigidBody?.MoveHorizontal(direction);
        Debug.Log("Персонаж двигается с направлением: " + direction);
    }
    public void ActionPressed()
    {
        if (PlayerState.Instance.IsStandingOnSecondPlatform && fruitState.IsTaiking)
        {
            objectInstantiater?.InstantiateObject(applePrefab);

            fruitState.SetIsTaking(false);

        }
        else if (PlayerState.Instance.IsNearTheTree && !FruitState.Instance.IsTaiking)
        {

            FruitState.Instance.SetIsTaking(true);

        }
    }
    public void ActionEnterPressed()
    {
        if (inventoryPlayer != null && inventoryPlayer.currentDynamites > 0)
        {
           
            dynamiteSpawner.SpawnAndInitializeDynamite();
            inventoryPlayer.MinusOneBomb();
            
        }


    }
}