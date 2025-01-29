using System.Collections.Generic;
using UnityEngine;
public class UpdateManager : MonoBehaviour
{
    // Список объектов, которые нужно обновлять
    private List<IUpdatable> updatables = new List<IUpdatable>();

    // Синглтон для UpdateManager
    public static UpdateManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // Этот объект не будет уничтожаться при смене сцены
        
    }

    public void Register(IUpdatable obj)
    {
        if (!updatables.Contains(obj)) // Если объект не содержится в списке updatables
        {
            updatables.Add(obj);
        }
    }

    public void Unregister(IUpdatable obj)
    {
        if (updatables.Contains(obj))
        {
            updatables.Remove(obj);
        }
    }

    private void Update()
    {
        foreach (var obj in updatables)
        {

            obj.CustomUpdate();
        }
    }
}

//Объяснение:
//updatables: Список всех объектов, которые реализуют интерфейс IUpdatable.
//Register: Добавляет объект в список для обновления.
//Unregister: Удаляет объект из списка.
//Update: Каждый кадр вызывает метод Update() у всех зарегистрированных объектов.