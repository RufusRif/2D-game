using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    [SerializeField] int currentDynamites = 0;
    


    public void PlusOneBomb()
    {
        if (currentDynamites < 3)
        {
            currentDynamites++;
        }
    }

    public void MinusOneBomb()
    {
        if (currentDynamites > 0)
        {
            currentDynamites--;
        }
            
    }
}
