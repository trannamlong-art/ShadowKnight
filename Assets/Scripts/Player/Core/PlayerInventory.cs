using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int maxHealthPotions;
    [SerializeField] private int goldAmount;

    public int MaxHealthPotions => maxHealthPotions;
    public int GoldAmount => goldAmount;

    public void AddHealthPotion(int amount)
    {
        if (amount <= 0) return;

        maxHealthPotions += amount;
    }
    public void AddGold(int amount)
    {
        if (amount <= 0) return;

        goldAmount += amount;
    }

    public bool TryUseHealPotion()
    {
        if (maxHealthPotions <= 0) return false;

        maxHealthPotions--;
        return true;
    }
    public bool TrySpendGold(int amount)
    {
        if (amount <= 0 || goldAmount < amount) return false;

        goldAmount -= amount;
        return true;
    }
}
