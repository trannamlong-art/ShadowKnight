using UnityEngine;

public class UpgradeStation : MonoBehaviour
{
    private Playerinput playerInput;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInput = other.GetComponent<Playerinput>();
        PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();

        if (playerRespawn != null)
        {
            playerRespawn.SetRespawnPoint(transform);
        }
    }

    private void Update()
    {
        if (playerInput != null && playerInput.interactInput)
        {
            UIManager uiManager = FindAnyObjectByType<UIManager>();
            if (uiManager != null)
            {
                uiManager.OpenUpgradePanel();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInput = null;
    }
}
