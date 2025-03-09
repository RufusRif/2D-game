using UnityEngine;

public class DynamiteAttackHandler : MonoBehaviour
{
    [SerializeField] private int damage = 1; 

    public void AttackEnemy(GameObject target)
    {
        // Проверяем, реализует ли объект интерфейс IDamageable
        IDamageable damageable = target.GetComponentInChildren<IDamageable>();
        if (damageable != null && damageable.IsAlive())
        {
            
            damageable.TakeDamage(damage);
        }
    }
}
