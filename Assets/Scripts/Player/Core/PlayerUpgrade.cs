using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Upgrade Settings")]
    [SerializeField] private float healthUpgradeAmount;
    [SerializeField] private float staminaUpgradeAmount;
    [SerializeField] private float staminaRegenRateIncrease;
    [SerializeField] private float attackDamageUpgradeAmount;

    [Header("Upgrade Costs")]
    [SerializeField] private int damageUpgradeCost;
    [SerializeField] private int healthUpgradeCost;
    [SerializeField] private int staminaUpgradeCost;
    [SerializeField] private int upgradeCostIncrement;

    private int damageLevel = 0;
    public int DamageLevel => damageLevel;
    private int healthLevel = 0;
    public int HealthLevel => healthLevel;
    private int staminaLevel = 0;
    public int StaminaLevel => staminaLevel;

    public int DamageUpgradeCost => damageUpgradeCost + damageLevel * upgradeCostIncrement;
    public int HealthUpgradeCost => healthUpgradeCost + healthLevel * upgradeCostIncrement;
    public int StaminaUpgradeCost => staminaUpgradeCost + staminaLevel * upgradeCostIncrement;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public bool UpgradeHealth()
    {
        if (healthLevel >= 5) return false;
        if (HealthUpgradeCost > playerController.Inventory.GoldAmount) return false;

        playerController.Inventory.TrySpendGold(HealthUpgradeCost);
        playerController.Health.IncreaseMaxHealth(healthUpgradeAmount);
        healthLevel++;
        return true;
    }

    public bool UpgradeStamina()
    {
        if (staminaLevel >= 5) return false;
        if (StaminaUpgradeCost > playerController.Inventory.GoldAmount) return false;

        playerController.Inventory.TrySpendGold(StaminaUpgradeCost);
        playerController.Combat.IncreaseMaxStamina(staminaUpgradeAmount, staminaRegenRateIncrease);
        staminaLevel++;
        return true;
    }

    public bool UpgradeAttackDamage()
    {
        if (damageLevel >= 5) return false;
        if (DamageUpgradeCost > playerController.Inventory.GoldAmount) return false;

        playerController.Inventory.TrySpendGold(DamageUpgradeCost);
        playerController.Combat.IncreaseAttackDamage(attackDamageUpgradeAmount);
        damageLevel++;
        return true;
    }
}
