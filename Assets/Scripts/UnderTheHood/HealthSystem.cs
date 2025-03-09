using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private Image[] lives;
    [SerializeField] private Sprite fullLive;
    [SerializeField] private Sprite emptyLive;
    [SerializeField] private int health;
    [SerializeField] private int numberOfLives;
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
    

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
       
        gameObject.SetActive(false);
    }
}
