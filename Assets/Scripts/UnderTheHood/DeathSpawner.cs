using UnityEngine;

public class DeathSpawner : MonoBehaviour
{
    [SerializeField] private ObjectInstantiater objectInstantiater;
    [SerializeField] private GameObject prefabToSpawn;

    public void SpawnObject()
    {
        objectInstantiater.InstantiateObject(prefabToSpawn);
    }
}
