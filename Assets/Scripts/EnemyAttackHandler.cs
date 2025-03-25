using System.Collections;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [SerializeField] private int damage = 1; 
    
    private Animator animator;

    private void Start()
    {
        
        animator = GetComponent<Animator>();
    }
    public void Attack(GameObject target)
    {
        // Проверяем, есть ли у цели интерфейс IDamageable
        IDamageable damageable = target.GetComponentInChildren<IDamageable>();

        if (damageable != null && damageable.IsAlive())
        {
            damageable.TakeDamage(damage); // Наносим урон
           
        }
    }
    public void PlayHitAnimation()
    {
            animator.SetTrigger("isHit"); // Активируем триггер isHit
    }
}

