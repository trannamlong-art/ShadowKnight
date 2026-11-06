using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private AudioManager audioManager;
    private PlayerRespawn playerRespawn;
    private EnemyRespawn enemyRespawn;

    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject respawnPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private TextMeshProUGUI tutorialText;

    [SerializeField] private GameObject movePanel;
    [SerializeField] private GameObject musicActive;

    private void Awake()
    {
        playerRespawn = FindAnyObjectByType<PlayerRespawn>();
        enemyRespawn = FindAnyObjectByType<EnemyRespawn>();
        audioManager = FindAnyObjectByType<AudioManager>();

        upgradePanel.SetActive(false);
        respawnPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        winPanel.SetActive(false);
        mainMenuPanel.gameObject.SetActive(true);
        movePanel.SetActive(false);
        musicActive.SetActive(false);
        Time.timeScale = 0f; // Pause the game at the start
    }

    public void OpenUpgradePanel()
    {
        audioManager.PlayOpenUpgradePanelSound();
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
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        musicActive.SetActive(false);
    }
    public void CloseMainMenuPanel()
    {
        mainMenuPanel.gameObject.SetActive(false);
        movePanel.SetActive(true);
        Time.timeScale = 1f;
        musicActive.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        mainMenuPanel.gameObject.SetActive(false);
        movePanel.SetActive(true);
        musicActive.SetActive(true);
    }
}
