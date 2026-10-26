using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUB : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerCombat playerCombat;
    private PlayerInventory playerInventory;
    [SerializeField] private Image healthFill;
    [SerializeField] private Image staminaFill;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI healthPotionText;

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        playerCombat = FindAnyObjectByType<PlayerCombat>();
        playerInventory = FindAnyObjectByType<PlayerInventory>();

        goldText.text = playerInventory.GoldAmount.ToString();
        healthPotionText.text = playerInventory.MaxHealthPotions.ToString();
    }
    void LateUpdate()
    {
        float healthRatio = playerHealth.CurrentHealth / playerHealth.MaxHealth;
        healthFill.fillAmount = Mathf.Clamp01(healthRatio);

        float staminaRatio = playerCombat.CurrentStamina / playerCombat.MaxStamina;
        staminaFill.fillAmount = Mathf.Clamp01(staminaRatio);

        goldText.text = playerInventory.GoldAmount.ToString();
        healthPotionText.text = playerInventory.MaxHealthPotions.ToString();
    }
}
