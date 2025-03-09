using UnityEngine;

public class HealthEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"{gameObject.name} takes {damage} damage! Current health: {currentHealth}");
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
    }
}