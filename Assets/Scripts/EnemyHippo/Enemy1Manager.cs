using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static Enemy1StateManager;

public class Enemy1Manager : MonoBehaviour
{
    private Enemy1StateManager enemy1StateManager;

    [SerializeField] private Transform playerTransform;
    //[SerializeField] private float detectionRange = 20f;
    private void Awake()
    {
        enemy1StateManager = GetComponent<Enemy1StateManager>();
    }
    private void Start()
    {
        enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.RandomMovement);
       
    }
    public void SetStateAttack(GameObject player)
    {
        
        playerTransform = player.transform;
        enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.Attack);
        
    }
    public void SetStateMovingToTarget(Transform player)
    {
        SoundManager.Instance.PlaySoundEffect("RhinoMoveToTarget");
        playerTransform = player;
        enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.MovingToTarget);
    }
    public void SetStateRandomMovement()
    {
        enemy1StateManager.SetState(Enemy1StateManager.Enemy1State.RandomMovement);
    }

}