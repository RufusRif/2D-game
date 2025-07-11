using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;
using UltEvents;
public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private Image[] lives;
    [SerializeField] private Sprite fullLive;
    [SerializeField] private Sprite emptyLive;
    [SerializeField] private int health;
    [SerializeField] private int numberOfLives;

    public UltEvents.UltEvent<GameObject> OnDeath;


    private void Start()
    {
        UpdateLivesUI();
    }
    private void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }
            lives[i].enabled = i < numberOfLives;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, numberOfLives);
        UpdateLivesUI();

        if (!IsAlive())
        {
            OnDeath.Invoke(gameObject);
        }
    }
    public bool IsAlive()
    {
        return health > 0;
    }
    public void Heal(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, numberOfLives);
        UpdateLivesUI();
    }
    //public void Die()
    //{
    //    transform.parent.gameObject.SetActive(false);
    //}
}
