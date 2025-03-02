using UnityEngine;

public class DynamiteSpawner : MonoBehaviour
{
    [SerializeField] private ObjectInstantiater objectInstantiater; 
    [SerializeField] private GameObject dynamitePrefab;            
    [SerializeField] private Transform player;                    

    public void SpawnAndInitializeDynamite()
    {
      
        GameObject dynamiteInstance = objectInstantiater.InstantiateObject(dynamitePrefab);

       
        PushTheDynamite pushScript = dynamiteInstance.GetComponent<PushTheDynamite>();

        if (pushScript != null)
        {
            
            pushScript.Initialize(player);

            
            pushScript.PushDynamite();
        }
        else
        {
            Debug.LogError("PushTheDynamite component not found on the instantiated object!");
        }
    }
}
