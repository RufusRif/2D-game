using UnityEngine;
using UnityEngine.UI;

public class FruitDisplay : MonoBehaviour
{
    [SerializeField] private Image image; // Ссылка на UI-изображение ореха


    public void SetImageAlphaFull()
    {
        if (image != null)
        {
            Color color = image.color; // Получаем текущий цвет
            color.a = 1f; // Изменяем альфа-канал
            image.color = color; // Присваиваем обратно
        }
    }

    // Метод для включения бледного состояния
    public void SetImageAlphaHalf()
    {
        if (image != null)
        {
            Color color = image.color; // Получаем текущий цвет
            color.a = 0.3f; // Изменяем альфа-канал
            image.color = color; // Присваиваем обратно
        }
    }
}

