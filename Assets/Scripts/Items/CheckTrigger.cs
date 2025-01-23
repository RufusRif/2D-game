using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"isNearTheTree стало в True " );
            PlayerState.Instance.SetIsNearTheTree(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"isNearTheTree стало в False ");
        PlayerState.Instance.SetIsNearTheTree(false);
    }
}
