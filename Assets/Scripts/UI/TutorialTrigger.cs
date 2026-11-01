using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField, TextArea(3, 6)] private string message;
    private UIManager uiManager;

    private bool hasShown;
    private void Awake()
    {
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || hasShown) return;

        if (uiManager != null)
        {
            uiManager.ShowTutorial(message);
            hasShown = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (uiManager != null)
        {
            uiManager.HideTutorial();
        }
    }
}
