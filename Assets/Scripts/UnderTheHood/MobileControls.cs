using UnityEngine;

public class MobileControls : MonoBehaviour
{
    [SerializeField] PlayerInputReader playerInputReader;

    public void MoveLeft()
    {
        playerInputReader.OnMove?.Invoke(-1);
    }

    public void MoveRight()
    {
        playerInputReader?.OnMove?.Invoke(1);
    }
    public void StopMoving()
    {
        playerInputReader.OnMove?.Invoke(0);
    }
    public void Jump()
    {
        playerInputReader.OnJump?.Invoke();
    }
    public void JumpDown()
    {
        playerInputReader.OnJumpDown?.Invoke();
    }
    public void Action()
    {
        playerInputReader.OnAction?.Invoke();
    }
    public void Attack()
    {
        playerInputReader.OnShot?.Invoke();
    }
}
