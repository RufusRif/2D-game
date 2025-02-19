using UnityEngine;
using UnityEngine.UIElements;

public class ParticleManager : MonoBehaviour
{
    
    public static ParticleManager Instance { get; private set; }

    
    public ParticleSystem explosionEffect;
    public ParticleSystem footstepParticles;
    public ParticleSystem objectLiftParticles;

    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this; // Устанавливаем текущий объект как синглтон
            DontDestroyOnLoad(gameObject); // Не уничтожаем объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject); // Если синглтон уже существует, уничтожаем дубликат
        }
    }
    public void PlayExplosion(Vector3 position)
    {
        if (explosionEffect != null)
        {
            ParticleSystem explosionInstance = Instantiate(explosionEffect, position, Quaternion.identity);
            explosionInstance.Play();

            Debug.Log("Взрыв произошел.");
            Destroy(explosionInstance.gameObject, explosionInstance.main.duration);
        }
        else
        {
            Debug.LogError("Explosion effect is not assigned!");
        }
    }
    public void PlayFootstepParticles(Vector3 position)
    {
        if (footstepParticles != null)
        {
            Instantiate(footstepParticles, position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Footstep particles are not assigned!");
        }
    } 
    public void PlayObjectLiftParticles(Vector3 position)
    {
        if (objectLiftParticles != null)
        {
            Instantiate(objectLiftParticles, position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Object lift particles are not assigned!");
        }
    }
}



