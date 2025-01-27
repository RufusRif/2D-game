using System;
using UnityEngine;


public class ObjectInstantiater : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; 
    [SerializeField] private Transform thrownPoint;
    //public event Action OnFruitInstantiated;


    public void InstantiateObject()
    {
        if (objectToSpawn != null && thrownPoint != null)
        {
            // Инстанцируем объект
            GameObject newObject = Instantiate(objectToSpawn, thrownPoint.position, thrownPoint.rotation);

            // Найдем компонент PushRigidBody и передадим ему ссылку на себя (ObjectInstantiater)
            PushRigidBody pushRigidBody = newObject.GetComponent<PushRigidBody>();
            if (pushRigidBody != null)
            {
                pushRigidBody.objectInstantiater = this; // Назначаем ссылку
                pushRigidBody.Push(); // Подкидываем объект
            }

            // Аналогично с другим компонентом
            ChangerLayer changerLayer = newObject.GetComponent<ChangerLayer>();
            if (changerLayer != null)
            {
                changerLayer.ChangeTheLayer(); // Меняем слой
            }
        }
    }
}


