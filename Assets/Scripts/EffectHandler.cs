using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    public void PlayExplosion(Vector3 position)
    {
        
        if (ParticleManager.Instance != null)
        {
            ParticleManager.Instance.PlayExplosion(position);
        }
        else
        {
            Debug.LogError("ParticleManager instance is not found!");
        }
    }
}
