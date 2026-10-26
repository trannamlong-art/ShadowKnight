using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyDetection : MonoBehaviour
{
    private LayerMask playerLayer;
    private EnemyMovement enemyMovement;
    private bool isPlayerDeath;

    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius;
    [SerializeField] private float attackZoneRadius;
    [SerializeField] private float detectionAngle;

    private Vector2 toPlayer;
    public Vector2 ToPlayer => toPlayer;

    private void Awake()
    {
        playerLayer = LayerMask.GetMask("Player");
        enemyMovement = GetComponent<EnemyMovement>();
        isPlayerDeath = FindAnyObjectByType<PlayerController>().currentState is PlayerStateDie;
    }

    public bool PlayerCanBeSee(float facingDirection)
    {
        isPlayerDeath = FindAnyObjectByType<PlayerController>().currentState is PlayerStateDie;
        if (isPlayerDeath) return false;

        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        if (playerCollider != null)
        {
            toPlayer = (playerCollider.transform.position - transform.position).normalized;
            Vector2 facingVector = facingDirection * transform.right;
            float angleToPlayer = Vector2.Angle(facingVector, toPlayer);
            return angleToPlayer <= detectionAngle / 2f;
        }
        return false;
    }

    public bool PlayerInDetectionZone()
    {
        isPlayerDeath = FindAnyObjectByType<PlayerController>().currentState is PlayerStateDie;
        if (isPlayerDeath) return false;

        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        if (playerCollider != null)
        {
            toPlayer = (playerCollider.transform.position - transform.position).normalized;
            return true;
        }
        return false;
    }

    public bool PlayerInAttackZone()
    {
        isPlayerDeath = FindAnyObjectByType<PlayerController>().currentState is PlayerStateDie;
        if (isPlayerDeath) return false;

        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, attackZoneRadius, playerLayer);
        if (playerCollider != null)
        {
            toPlayer = (playerCollider.transform.position - transform.position).normalized;
            return true;
        }
        return false;
    }

    public bool PlayerCanBeTarget()
    {
        if (PlayerInAttackZone())
        {
            return true;
        }
        else if (PlayerInDetectionZone() && PlayerCanBeSee(enemyMovement.FacingDirection))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyMovement == null)
        {
            enemyMovement = GetComponent<EnemyMovement>();
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackZoneRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position
                        + (Vector3)(Quaternion.Euler(0, 0, detectionAngle / 2f)
                        * (enemyMovement.FacingDirection * transform.right) * detectionRadius));
        Gizmos.DrawLine(transform.position, transform.position
                        + (Vector3)(Quaternion.Euler(0, 0, -detectionAngle / 2f)
                        * (enemyMovement.FacingDirection * transform.right) * detectionRadius));
    }
}