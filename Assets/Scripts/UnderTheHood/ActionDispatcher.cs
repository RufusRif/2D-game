using UnityEngine;
using UnityEngine.Events;

public class ActionDispatcher : MonoBehaviour
{

    
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
    [SerializeField] GameObject player;

    [SerializeField] SoundManager soundManager;
    public static ActionDispatcher Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void UpButtonPressed()
    {
        if (PlayerState.Instance.IsOnGround || PlayerState.Instance.IsStandingOnPlatform)
        {
            pushRigidBody?.Push();
            soundManager.PlaySoundEffect("PlayerJump");

        }

        else if (PlayerState.Instance.IsHanging)
        {
            changerLayer?.ChangeTheLayer();
            pushRigidBody?.Push();
            positionUnstopper?.UnStopPossition();
            soundManager.PlaySoundEffect("PlayerJump");
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
        if (fruitState.IsTaiking)
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
            SoundManager.Instance.PlaySoundEffect("PlayerThrowDynamite");
        }
    }

    // Это публичное свойство — его могут использовать другие скрипты
    public PositionStopper PlayerStopper
    {
        get
        {
            if (player == null)
            {
                return null;
            }
            PositionStopper stopper = player.GetComponent<PositionStopper>();

            return stopper;
        }
    }
}