using UnityEngine;

public class UpgradeStation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager uiManager = FindAnyObjectByType<UIManager>();
            if (uiManager != null)
            {
                uiManager.OpenUpgradePanel();
            }
            Debug.Log("Player entered the upgrade station.");
        }
        Debug.Log("Collider entered: " + other.name);
    }
}
