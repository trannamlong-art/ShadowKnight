using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private PlayerRespawn playerRespawn;
    private EnemyRespawn enemyRespawn;

    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject respawnPanel;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI tutorialText;

    private void Awake()
    {
        playerRespawn = FindAnyObjectByType<PlayerRespawn>();
        enemyRespawn = FindAnyObjectByType<EnemyRespawn>();

        upgradePanel.SetActive(false);
        respawnPanel.SetActive(false);
        tutorialPanel.SetActive(false);
    }

    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void OpenRepawnPanel()
    {
        respawnPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
    public void CloseRespawnPanel()
    {
        respawnPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        enemyRespawn.RespawnEnemies(); // Call the respawn method to reset the enemies' state
        playerRespawn.RespawnPlayer(); // Call the respawn method to reset the player's state
    }
    public void ShowTutorial(string message)
    {
        tutorialText.text = message;
        tutorialPanel.SetActive(true);
    }
    public void HideTutorial()
    {
        if (tutorialPanel == null) return;

        tutorialPanel.SetActive(false);
    }
}
