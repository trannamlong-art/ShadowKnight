using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int maxHealthPotions;
    private int currentHealthPotions;
    [SerializeField] private int goldAmount;

    public int MaxHealthPotions => maxHealthPotions;
    public int CurrentHealthPotions => currentHealthPotions;
    public int GoldAmount => goldAmount;

    private void Awake()
    {
        currentHealthPotions = maxHealthPotions;
    }

    public void AddHealthPotion(int amount)
    {
        if (amount <= 0) return;

        currentHealthPotions += amount;
        if (currentHealthPotions > maxHealthPotions)
        {
            currentHealthPotions = maxHealthPotions;
        }
    }
    public void AddGold(int amount)
    {
        if (amount <= 0) return;

        goldAmount += amount;
    }

    public bool TryUseHealPotion()
    {
        if (currentHealthPotions <= 0) return false;

        currentHealthPotions--;
        return true;
    }
    public bool TrySpendGold(int amount)
    {
        if (amount <= 0 || goldAmount < amount) return false;

        goldAmount -= amount;
        return true;
    }
    public void RestoreHealthPotions(int amount)
    {
        if (amount <= 0) return;

        currentHealthPotions += amount;
        if (currentHealthPotions > maxHealthPotions)
        {
            currentHealthPotions = maxHealthPotions;
        }
    }
}
