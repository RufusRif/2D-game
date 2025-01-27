using System;
using UnityEngine;


public class ObjectInstantiater : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; 
    [SerializeField] private Transform thrownPoint;
    public event Action OnFruitInstantiated;


    public void InstantiateObject()
    {
        if (objectToSpawn != null && thrownPoint != null)
        {
            GameObject newObject = Instantiate(objectToSpawn, thrownPoint.position, thrownPoint.rotation);

            PushRigidBody pushRigidBody = newObject.GetComponent<PushRigidBody>(); 
            OnFruitInstantiated?.Invoke();
        }
    }
}


