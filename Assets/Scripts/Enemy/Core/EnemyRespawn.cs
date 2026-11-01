using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    private GameObject[] enemies;
    public void RespawnEnemies()
    {
        EnemyController[] enemies =
            FindObjectsByType<EnemyController>(
            FindObjectsInactive.Include
    );

        foreach (EnemyController enemy in enemies)
        {
            enemy.ResetEnemy();
        }
    }
}
