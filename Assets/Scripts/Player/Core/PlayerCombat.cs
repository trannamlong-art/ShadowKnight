using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCombat : MonoBehaviour
{
    private PlayerController playerController;
    private Collider2D playerCollider;
    private readonly HashSet<Collider2D> ignoredEnemies = new();

    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDamage;
    [SerializeField] private float heavyAttackDamage;
    [SerializeField] private GameObject attackEffectPrefab;

    [Header("Skill Settings")]
    [SerializeField] private float skillDamage;
    [SerializeField] private float skillCooldown;

    [Header("Stamina Settings")]
    [SerializeField] private float maxStamina;
    [SerializeField] private float staminaRegenRate;
    [SerializeField] private float staminaRegenDelay;
    [SerializeField] private float heavyAttackStaminaCost;
    [SerializeField] private float attackStaminaCost;
    [SerializeField] private float rollStaminaCost;
    private float currentStamina;
    private float nextStaminaRegenTime;

    public float SkillCooldown => skillCooldown;

    public float CurrentStamina => currentStamina;
    public float MaxStamina => maxStamina;
    public float AttackStaminaCost => attackStaminaCost;
    public float HeavyAttackStaminaCost => heavyAttackStaminaCost;
    public float RollStaminaCost => rollStaminaCost;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerCollider = GetComponent<Collider2D>();
        currentStamina = maxStamina;
    }
    private void Update()
    {
        if (nextStaminaRegenTime > Time.time) return;

        currentStamina = Mathf.MoveTowards(currentStamina, maxStamina, staminaRegenRate * Time.deltaTime);
    }
    public void DisableEnemyCollisions(bool rolling)
    {
        if (rolling)
        {
            Collider2D[] enemiesCollider = Physics2D.OverlapCircleAll(
                transform.position,
                1.0f,
                LayerMask.GetMask("Enemy"));

            foreach (Collider2D enemyCollider in enemiesCollider)
            {
                if (ignoredEnemies.Add(enemyCollider))
                {
                    Physics2D.IgnoreCollision(playerCollider, enemyCollider, true);
                }
            }
        }
        else
        {
            foreach (Collider2D enemyCollider in ignoredEnemies)
            {
                if (enemyCollider != null)
                {
                    Physics2D.IgnoreCollision(playerCollider, enemyCollider, false);
                }
            }

            ignoredEnemies.Clear();
        }
    }
    public void PlayerAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, LayerMask.GetMask("Enemy"));
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (!enemyHealth) return;
            enemyHealth.TakeDamage(attackDamage);

            SpawnAttackEffect(enemy);
        }
    }
    public void PlayerHeavyAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, LayerMask.GetMask("Enemy"));
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (!enemyHealth) return;
            enemyHealth.TakeDamage(heavyAttackDamage);

            SpawnAttackEffect(enemy);
        }
    }
    public void PlayerSkill()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, LayerMask.GetMask("Enemy"));
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (!enemyHealth) return;
            enemyHealth.TakeDamage(skillDamage);

            SpawnAttackEffect(enemy);
        }
    }
    public bool TrySpendStamina(float staminaCost)
    {
        if (currentStamina < staminaCost) return false;

        currentStamina -= staminaCost;
        nextStaminaRegenTime = Time.time + staminaRegenDelay;
        return true;
    }
    public bool SkillCooldownReset()
    {
        if (skillCooldown > Time.time) return false;

        skillCooldown += Time.time;
        return true;
    }
    public void SpawnAttackEffect(Collider2D enemy)
    {
        if (attackEffectPrefab != null && attackPoint != null)
        {
            GameObject slash = Instantiate(attackEffectPrefab, enemy.transform.position - new Vector3(0, 2, 0), Quaternion.identity);

            Vector3 scale = slash.transform.localScale;
            scale.x = Mathf.Abs(scale.x) * playerController.Movement.facingDirection;
            slash.transform.localScale = scale;
        }
    }

    public void IncreaseMaxStamina(float amount, float staminaRegenRateIncrease)
    {
        maxStamina += amount;
        staminaRegenRate += staminaRegenRateIncrease;
        currentStamina = Mathf.Min(currentStamina + amount, maxStamina);
    }
    public void IncreaseAttackDamage(float amount)
    {
        attackDamage += amount;
        heavyAttackDamage += amount;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}