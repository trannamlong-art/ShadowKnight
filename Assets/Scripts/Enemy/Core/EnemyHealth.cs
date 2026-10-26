using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyController enemy;
    private PlayerController player;
    [SerializeField] private EnemyData enemyData;
    private float currentHealth;

    public float CurrentHealth => currentHealth;

    private void Awake()
    {
        enemy = GetComponent<EnemyController>();
        player = FindAnyObjectByType<PlayerController>();
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;

        if (enemy.Shield != null && enemy.Shield.isShieldActive)
        {
            damage = Mathf.Max(0, damage - enemyData.shieldDamageReduction);
        }
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            enemy.ChangeState(new EnemyStateDie(enemy));
            int goldAmount = Random.Range(enemyData.minGold, enemyData.maxGold + 1);
            player.GetComponent<PlayerInventory>().AddGold(goldAmount);
        }
        else if (enemy.currentState is EnemyStateShield)
        {
            enemy.Movement.EnemyKnockback(enemy.Movement.KnockbackForce * enemy.Detection.ToPlayer);
        }
        else
        {
            enemy.Movement.EnemyKnockback(enemy.Movement.KnockbackForce * enemy.Detection.ToPlayer);
            enemy.ChangeState(new EnemyStateHurt(enemy));
        }
    }
}