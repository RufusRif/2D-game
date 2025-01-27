using UnityEngine;

public class ActionDispatcher : MonoBehaviour
{
    [SerializeField] PushRigidBody pushRigidBody;
    [SerializeField] ChangerLayer changerLayer;
    [SerializeField] PositionUnstopper positionUnstopper;
    [SerializeField] MoverRigidBodyRightLeft moverRigidBody;
    [SerializeField] ObjectInstantiater objectInstantiater;
    [SerializeField] FruitState fruitState;

    public void UpButtonPressed()
    {
        if (PlayerState.Instance.IsOnGround || PlayerState.Instance.IsStandingOnPlatform)
        {
            pushRigidBody?.Push();
        }

        if (PlayerState.Instance.IsHanging)
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
        else if (PlayerState.Instance.IsHanging)
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
            objectInstantiater?.InstantiateObject();
            fruitState.SetIsTaking(false);
        }
    }
}



