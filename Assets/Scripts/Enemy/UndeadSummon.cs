using UnityEngine;

public class UndeadSummon : MonoBehaviour
{
    private EnemyController enemyController;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Transform[] summonPoints;
    [SerializeField] private GameObject summonPrefab;
    private GameObject[] minionPool;
    private float nextSummonTime;
    private bool canSummon;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();

        minionPool = new GameObject[summonPoints.Length];
        for (int i = 0; i < summonPoints.Length; i++)
        {
            minionPool[i] = Instantiate(summonPrefab, summonPoints[i].position, Quaternion.identity);
            minionPool[i].SetActive(false);
        }
    }

    public void ActiveSummon()
    {
        for (int i = 0; i < minionPool.Length; i++)
        {
            GameObject minion = minionPool[i];

            if (minion.activeSelf) continue;

            minion.transform.position = summonPoints[i].position;
            minion.transform.SetParent(summonPoints[i], true);
            minion.SetActive(true);
        }
    }
    public void DisableSummon()
    {
        for (int i = 0; i < minionPool.Length; i++)
        {
            GameObject minion = minionPool[i];

            if (!minion.activeSelf) continue;

            minion.SetActive(false);
        }
    }

    public bool SummonCooldown()
    {
        if (nextSummonTime > Time.time || !canSummon) return false;

        nextSummonTime = Time.time + enemyData.summonCooldown;
        return true;
    }

    public void CanSummon()
    {
        canSummon = true;
    }
    public void CannotSummon()
    {
        canSummon = false;
    }
}
