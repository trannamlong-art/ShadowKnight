using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private float maxHealth;
    private float currentHealth;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage, Transform attackerTransform)
    {
        if (player.currentState is PlayerStateHurt || player.currentState is PlayerStateRoll) return;

        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current health: {currentHealth}");
        float knockbackDirection = Mathf.Sign(transform.position.x - attackerTransform.position.x);
        player.Movement.PlayerKnockBack(player.Movement.KnockbackForce * knockbackDirection);

        if (currentHealth <= 0)
        {
            player.ChangeState(new PlayerStateDie(player));
        }
        else
        {
            player.ChangeState(new PlayerStateHurt(player));
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void RestoreFullHealth()
    {
        currentHealth = maxHealth;
    }
    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        currentHealth += amount; // Optionally heal the player when max health increases
    }
}