using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UIManager instance;

    [SerializeField] private GameObject upgradePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        upgradePanel.SetActive(false);
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
}
