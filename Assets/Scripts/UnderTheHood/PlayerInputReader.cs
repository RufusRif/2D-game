using UnityEngine;
using UnityEngine.Events;

public class PlayerInputReader : MonoBehaviour
{
        private InputSystem_Actions inputActions;

    // События для действий
    public UnityEvent<float> OnMove;
    public UnityEvent OnJump;
    public UnityEvent OnAction;
    public UnityEvent OnJumpDown;
    private void Awake()
    {

        inputActions = new InputSystem_Actions();

        // Привязка методов к действиям
        inputActions.Player.Move.performed += ctx =>
        {
            float direction = ctx.ReadValue<Vector2>().x; // Считываем направление по X (-1, 0, 1)
            OnMove?.Invoke(direction);
        };

        inputActions.Player.Move.canceled += _ => OnMove?.Invoke(0);//

        inputActions.Player.Jump.performed += _ => OnJump?.Invoke();

        inputActions.Player.Action.performed += _ => OnAction?.Invoke();

        inputActions.Player.JumpDown.performed += _ => OnJumpDown?.Invoke();

    }
    private void OnEnable()
    {
        // Включаем Input Actions
        inputActions.Enable();
    }
    private void OnDisable()
    {
        // Отключаем Input Actions
        inputActions.Disable();
    }
}
