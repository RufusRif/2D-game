using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [SerializeField] private int damage = 1; 
    public void Attack(GameObject target)
    {
        // Находим компонент IDamageable на объекте Player или его дочерних объектах
        IDamageable damageable = target.GetComponentInChildren<IDamageable>();

        if (damageable != null && damageable.IsAlive())
        {
            damageable.TakeDamage(damage);
        }
    }
}
