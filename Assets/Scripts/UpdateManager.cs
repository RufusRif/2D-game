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
        // Проверка, если экземпляр уже существует
        if (Instance != null && Instance != this) //Если экземпляр уже существует (не равен null и не является текущим объектом)
        {
            Destroy(gameObject);  // Уничтожаем дублирующийся экземпляр
        }
        else
        {
            Instance = this;  // Присваиваем текущий экземпляр
            DontDestroyOnLoad(gameObject); // Не уничтожать объект при смене сцены (по желанию)
        }
    }

    // Регистрация объекта
    public void Register(IUpdatable obj)
    {
        if (!updatables.Contains(obj)) // Если объект не содержится в списке updatables
        {
            updatables.Add(obj);
        }
    }

    // Удаление объекта из списка
    public void Unregister(IUpdatable obj)
    {
        if (updatables.Contains(obj))
        {
            updatables.Remove(obj);
        }
    }

    // Вызывается каждый кадр
    private void Update()
    {
        foreach (var obj in updatables)
        {
            obj.Update();
        }
    }
}

//Объяснение:
//updatables: Список всех объектов, которые реализуют интерфейс IUpdatable.
//Register: Добавляет объект в список для обновления.
//Unregister: Удаляет объект из списка.
//Update: Каждый кадр вызывает метод Update() у всех зарегистрированных объектов.