using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    public void PlayExplosion(Vector3 position)
    {
        ParticleManager.Instance.PlayExplosion(position);
    }
    public void PlayDynamiteExplotionOnEnemy(Vector3 position)
    {
        ParticleManager.Instance.PlayDynamiteExplotionOnEnemy(position);
    }
}