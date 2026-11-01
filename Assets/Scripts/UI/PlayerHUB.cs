using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUB : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerCombat playerCombat;
    private PlayerInventory playerInventory;

    [Header("UI TopLeft")]
    [SerializeField] private Image healthFill;
    [SerializeField] private Image staminaFill;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI healthPotionText;

    [Header("UI Skill")]
    [SerializeField] private GameObject cooldownImage;
    [SerializeField] private TextMeshProUGUI cooldownText;

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        playerCombat = FindAnyObjectByType<PlayerCombat>();
        playerInventory = FindAnyObjectByType<PlayerInventory>();

        goldText.text = playerInventory.GoldAmount.ToString();
        healthPotionText.text = playerInventory.CurrentHealthPotions.ToString();

        cooldownImage.SetActive(false);
        cooldownText.text = "";
    }
    void LateUpdate()
    {
        float healthRatio = playerHealth.CurrentHealth / playerHealth.MaxHealth;
        healthFill.fillAmount = Mathf.Clamp01(healthRatio);

        float staminaRatio = playerCombat.CurrentStamina / playerCombat.MaxStamina;
        staminaFill.fillAmount = Mathf.Clamp01(staminaRatio);

        goldText.text = playerInventory.GoldAmount.ToString();
        healthPotionText.text = playerInventory.CurrentHealthPotions.ToString();

        float remainingCooldown = playerCombat.SkillCooldownRemaining;

        cooldownImage.SetActive(remainingCooldown > 0);
        cooldownText.text = remainingCooldown > 0 ? Mathf.CeilToInt(remainingCooldown).ToString() : "";
    }
}
