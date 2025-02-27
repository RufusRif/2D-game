using System;
using UnityEngine;


public class ObjectInstantiater : MonoBehaviour
{
    [SerializeField] private Transform thrownPoint;
    public GameObject InstantiateObject(GameObject prefab)
    {
        if (thrownPoint == null)
        {
            Debug.LogError("Thrown point is not assigned!");
            return null;
        }

        if (prefab == null)
        {
            Debug.LogError("Prefab is not assigned!");
            return null;
        }
        return Instantiate(prefab, thrownPoint.position, thrownPoint.rotation);
    }
}



















//[SerializeField] private GameObject objectToSpawn; 
//[SerializeField] private Transform thrownPoint;


//public void InstantiateObject()
//{
//    if (objectToSpawn != null && thrownPoint != null)
//    {
//        GameObject newObject = Instantiate(objectToSpawn, thrownPoint.position, thrownPoint.rotation);
//    }
//}