using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            PlayerState.Instance.SetIsNearTheTree(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        PlayerState.Instance.SetIsNearTheTree(false);
    }
}
