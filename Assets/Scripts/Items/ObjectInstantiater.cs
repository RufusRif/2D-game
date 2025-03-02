using System;
using UnityEngine;


public class ObjectInstantiater : MonoBehaviour
{
    [SerializeField] private Transform thrownPoint;
    public GameObject InstantiateObject(GameObject prefab)
    {
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