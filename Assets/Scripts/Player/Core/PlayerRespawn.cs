using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private PlayerController player;
    private UIManager uiManager;
    private AudioManager audioManager;
    private Rigidbody2D rb;

    [SerializeField] private Transform respawnPoint;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        uiManager = FindAnyObjectByType<UIManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
        if (audioManager != null)
        {
            audioManager.PlayChangeRespawnPointSound();
        }
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
        player.Health.RestoreFullHealth(); // Restore health to max
        player.Combat.RestoreStamina(player.Combat.MaxStamina); // Restore stamina to max
        player.Inventory.RestoreHealthPotions(player.Inventory.MaxHealthPotions); // Restore health potions to max
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        player.ChangeState(new PlayerStateIdle(player)); // Change state to idle after respawn
        player.Input.DisableButton(false); // Enable player input after respawn
    }
}
