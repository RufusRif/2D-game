using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPlayer : MonoBehaviour
{
    [SerializeField] private int currentDynamites;

    public int CurrentDynamites
    {
        get => currentDynamites;

        //set
        //{
        //    if (value >= 0 && value <= 3)
        //    {
        //        currentDynamites = value;
        //        UpdateDynamiteCountText();
        //    }
        //}
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
