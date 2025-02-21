using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryPlayer : MonoBehaviour
{
    [SerializeField] private int currentDynamites;

    public UnityEvent NumberOfBombsZero;

    public int CurrentDynamites
    {
        get => currentDynamites;
    }

    [SerializeField] private TMP_Text dynamiteCountText;
    public void PlusOneBomb()
    {
        if (currentDynamites < 3)
        {
            currentDynamites++;
            UpdateDynamiteCountText();
        }
    }
    public void MinusOneBomb()
    {
        if (currentDynamites > 0)
        {
            currentDynamites--;
            UpdateDynamiteCountText();
            CheckNumberOfBombs();
        }

    }

    public void CheckNumberOfBombs()
    {
        if (currentDynamites == 0)
        { 
            NumberOfBombsZero?.Invoke();
            Debug.Log("событие что бомбы закончились сработало");
        }
    }

    private void UpdateDynamiteCountText()
    {

        dynamiteCountText.text = currentDynamites.ToString();
    }
    private void Start()
    {

        UpdateDynamiteCountText();
    }
}
