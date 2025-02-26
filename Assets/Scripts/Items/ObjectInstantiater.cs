using System;
using UnityEngine;


public class ObjectInstantiater : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; 
    [SerializeField] private Transform thrownPoint;
    

    public void InstantiateObject()
    {
        if (objectToSpawn != null && thrownPoint != null)
        {
            GameObject newObject = Instantiate(objectToSpawn, thrownPoint.position, thrownPoint.rotation);
        }
    }
}