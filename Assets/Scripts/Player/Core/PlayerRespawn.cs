using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private PlayerController player;
    private UIManager uiManager;

    [SerializeField] private Transform respawnPoint;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        uiManager = FindAnyObjectByType<UIManager>();
    }

    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    public void OpenRepawnPanelWhenPlayerDie()
    {
        if (uiManager != null)
        {
            uiManager.OpenRepawnPanel();
        }
    }
    public void RespawnPlayer()
    {
        player.transform.position = respawnPoint.position + new Vector3(0, 2, 0); // Adjust the Y position to avoid spawning inside the ground
        player.Health.Heal(player.Health.MaxHealth); // Restore health to max
        player.Combat.RestoreStamina(player.Combat.MaxStamina); // Restore stamina to max
        player.Inventory.RestoreHealthPotions(player.Inventory.MaxHealthPotions); // Restore health potions to max
        player.ChangeState(new PlayerStateIdle(player)); // Change state to idle after respawn
        player.Input.DisableButton(false); // Enable player input after respawn
    }
}
