using UnityEngine;

public class TakingNutTurningOnDisplay : MonoBehaviour
{
   public void TakeTheNut()
    {
        if(PlayerState.Instance.IsNearTheTree && !NutState.Instance.IsTaiking)
        {
            Debug.Log("The nut tooked");
            NutState.Instance.SetIsTaking(true);
        }
        
    }
}
