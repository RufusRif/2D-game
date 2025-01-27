using UnityEngine;

public class TakingFruit : MonoBehaviour
{
   public void TakeTheFruit()
    {
        if(PlayerState.Instance.IsNearTheTree && !FruitState.Instance.IsTaiking)
        {
            
            FruitState.Instance.SetIsTaking(true);
        }
        
    }
}
