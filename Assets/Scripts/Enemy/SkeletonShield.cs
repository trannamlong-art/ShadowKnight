using UnityEngine;
using System.Collections;

public class SkeletonShield : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    public bool isShieldActive { get; private set; }
    public float shieldCooldown { get; private set; }

    public void StarBlocking()
    {
        if (isShieldActive) return;

        isShieldActive = true;

    }
    public void DisableShield()
    {
        if (!isShieldActive) return;

        isShieldActive = false;
    }
    public void ActiveShieldColdown()
    {
        shieldCooldown = Time.time + enemyData.shieldCooldown;
    }
    public bool CanActivateShield()
    {
        return Time.time >= shieldCooldown;
    }
}
