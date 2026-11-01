using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerUpgrade playerUpgrade;
    private PlayerInventory playerInventory;
    private EnemyRespawn enemyRespawn;

    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Image[] damageSlots;
    [SerializeField] private TextMeshProUGUI damageCostTexts;
    private Color upgradeDamageColor = Color.red;
    [SerializeField] private Image[] healthSlots;
    [SerializeField] private TextMeshProUGUI healthCostTexts;
    private Color upgradeHealthColor = Color.green;
    [SerializeField] private Image[] staminaSlots;
    [SerializeField] private TextMeshProUGUI staminaCostTexts;
    private Color upgradeStaminaColor = Color.yellow;

    private Color lockColor = Color.gray;

    private void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        playerUpgrade = FindAnyObjectByType<PlayerUpgrade>();
        playerInventory = FindAnyObjectByType<PlayerInventory>();
        enemyRespawn = FindAnyObjectByType<EnemyRespawn>();

        for (int i = 0; i < damageSlots.Length; i++)
        {
            damageSlots[i].color = lockColor;
        }
        for (int i = 0; i < healthSlots.Length; i++)
        {
            healthSlots[i].color = lockColor;
        }
        for (int i = 0; i < staminaSlots.Length; i++)
        {
            staminaSlots[i].color = lockColor;
        }
    }
    private void Update()
    {
        goldText.text = playerInventory.GoldAmount.ToString();
        damageCostTexts.text = playerUpgrade.DamageUpgradeCost.ToString();
        healthCostTexts.text = playerUpgrade.HealthUpgradeCost.ToString();
        staminaCostTexts.text = playerUpgrade.StaminaUpgradeCost.ToString();

        if (playerUpgrade.DamageLevel >= 5)
        {
            damageCostTexts.text = "MAX";
        }
        if (playerUpgrade.HealthLevel >= 5)
        {
            healthCostTexts.text = "MAX";
        }
        if (playerUpgrade.StaminaLevel >= 5)
        {
            staminaCostTexts.text = "MAX";
        }
    }
    public void UpgradeDamage()
    {
        if (!playerUpgrade.UpgradeAttackDamage()) return;

        for (int i = 0; i < damageSlots.Length; i++)
        {
            if (i < playerUpgrade.DamageLevel)
            {
                damageSlots[i].color = upgradeDamageColor;
            }
            else
            {
                damageSlots[i].color = lockColor;
            }
        }
    }

    public void UpgradeHealth()
    {
        if (!playerUpgrade.UpgradeHealth()) return;

        for (int i = 0; i < healthSlots.Length; i++)
        {
            if (i < playerUpgrade.HealthLevel)
            {
                healthSlots[i].color = upgradeHealthColor;
            }
            else
            {
                healthSlots[i].color = lockColor;
            }
        }
    }

    public void UpgradeStamina()
    {
        if (!playerUpgrade.UpgradeStamina()) return;

        for (int i = 0; i < staminaSlots.Length; i++)
        {
            if (i < playerUpgrade.StaminaLevel)
            {
                staminaSlots[i].color = upgradeStaminaColor;
            }
            else
            {
                staminaSlots[i].color = lockColor;
            }
        }
    }
    public void Rest()
    {
        playerController.Health.Heal(playerController.Health.MaxHealth);
        playerController.Combat.RestoreStamina(playerController.Combat.MaxStamina);
        playerController.Inventory.RestoreHealthPotions(playerController.Inventory.MaxHealthPotions);
        playerController.Combat.ResetSkillAfterRest();

        enemyRespawn.RespawnEnemies();
    }
}
