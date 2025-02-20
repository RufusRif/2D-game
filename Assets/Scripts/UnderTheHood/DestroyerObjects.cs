using UnityEngine;

public class DestroyerObjects : MonoBehaviour
{
    [SerializeField] string TagOfTochedObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagOfTochedObject))
        {
            Destroy(collision.gameObject);

            Vector3 explosionPosition = collision.transform.position;

            ParticleManager.Instance.PlayExplosion(explosionPosition);

        }
    }
}
