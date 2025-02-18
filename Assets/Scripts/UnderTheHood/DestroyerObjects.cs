using UnityEngine;

public class DestroyerObjects : MonoBehaviour
{
    [SerializeField] string TagOfTochedObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagOfTochedObject))
        {

            Destroy(collision.gameObject);
        }
    }
}
