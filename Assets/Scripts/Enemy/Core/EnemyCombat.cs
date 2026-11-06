using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    private float lastAttackTime = float.NegativeInfinity;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;

    public int attackIndex { get; private set; }

    void Awake()
    {

    }

    public void EnemyAttack()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Player"));

        foreach (Collider2D enemy in enemiesHit)
        {
            PlayerHealth playerHealth = enemy.GetComponent<PlayerHealth>();
            Transform transform = GetComponent<Transform>();
            if (playerHealth != null)
            {
                if (playerHealth.CurrentHealth <= 0f) return;
                playerHealth.TakeDamage(enemyData.attackDamage, transform);
            }
        }
    }

    public bool CanAttack()
    {
        return Time.time >= lastAttackTime + enemyData.attackCooldown;
    }
    public void NextAttack()
    {
        attackIndex++;
        if (attackIndex >= enemyData.attackAnimations.Length)
        {
            attackIndex = 0;
        }
    }
    public void StartAttackCooldown()
    {
        lastAttackTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}