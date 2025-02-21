using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private InventoryPlayer inventoryPlayer;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject catchedObject;

    public void Shot()
    {
        if (inventoryPlayer.CurrentDynamites > 0)
        {
            Instantiate(catchedObject, spawnPoint.position, Quaternion.identity);
            inventoryPlayer.MinusOneBomb();
        }
        else
        {
            Debug.Log("Нету динамитов в наличии");
        }
    }   
}
