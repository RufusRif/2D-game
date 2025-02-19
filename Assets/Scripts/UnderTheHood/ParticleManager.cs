using UnityEngine;
using UnityEngine.UIElements;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager Instance { get; private set; }


    public ParticleSystem explosionEffect;
    public ParticleSystem dust;
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
        ParticleSystem explosionInstance = Instantiate(explosionEffect, position, Quaternion.identity);
        explosionInstance.Play();

        Destroy(explosionInstance.gameObject, explosionInstance.main.duration);
    }
    public void CreateDust()
    {
        //Instantiate(footstepParticles, position, Quaternion.identity);
        dust.Play();
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



