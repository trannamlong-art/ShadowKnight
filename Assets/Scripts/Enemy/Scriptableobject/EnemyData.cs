using UnityEngine;

public enum EnemyType
{
    Skeleton,
    Goblin,
    Mushroom,
    Flyingeye
}


[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public EnemyType enemyType;
    public string[] attackAnimations;
    public int minGold;
    public int maxGold;

    [Header("Enemy Stats")]
    public float moveSpeed;
    public float maxHealth;
    public float attackDamage;
    public float attackCooldown;

    [Header("Enemy Skeleton Type")]
    public float shieldTime;
    public float shieldCooldown;
    public float shieldDamageReduction;

    [Header("Enemy Has Dash Ability Type")]
    public float DashForce;

}
