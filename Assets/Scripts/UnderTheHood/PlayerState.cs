using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; private set; }

    public bool IsHanging { get; private set; }
    public bool IsStandingOnPlatform {  get; private set; }

    public bool IsOnGround {  get; private set; }

    private void Awake()
    {
        // Проверяем, чтобы в сцене был только один экземпляр PlayerState
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Попытка создания второго экземпляра PlayerState: " + gameObject.name);

            Destroy(gameObject); // Уничтожаем лишние экземпляры
            return;
        }
        Debug.Log("Экземпляр синглтона создан: " + gameObject.name);
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    // Установка состояния: висит/не висит
    public void SetHangingState(bool isHanging)
    {
        IsHanging = isHanging;
    }

    public void SetStandingOnPlatform(bool isStandingOnPlatform)
    {
        IsStandingOnPlatform = isStandingOnPlatform;
    }

    public void SetOnGround(bool isOnGround)
    {
        IsOnGround = isOnGround;
    }

}
