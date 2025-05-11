using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;



    public UnityEvent EnemyHippoDead;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        if (!IsAlive())
        {
            Die();
        }
    }
    public bool IsAlive()
    {
        return currentHealth > 0;
    }
    private void Die()
    {
        Destroy(transform.parent.gameObject);
        EnemyHippoDead?.Invoke();
    }
}