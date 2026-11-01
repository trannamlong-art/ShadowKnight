using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private Rigidbody2D rb;
    private float facingDirection => Mathf.Sign(transform.localScale.x);
    [SerializeField] private float knockbackForce;
    private Vector3 initialPosition;
    private Vector3 initialScale;

    public Vector3 InitialPosition => initialPosition;
    public Vector3 InitialScale => initialScale;

    public float FacingDirection => facingDirection;
    public float KnockbackForce => knockbackForce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        initialScale = transform.localScale;
    }

    public void EnemyMove(Vector2 direction)
    {
        rb.linearVelocity = new Vector2(direction.x * enemyData.moveSpeed, rb.linearVelocity.y);
    }
    public void EnemyStopMove()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }
    public void EnemyFlip(float direction)
    {
        Vector3 scale = transform.localScale;
        if (direction > 0.01f)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (direction < -0.01f)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    public void EnemyKnockback(Vector2 knockback)
    {
        rb.AddForce(Vector2.left * knockback, ForceMode2D.Impulse);
    }
    public void EnemyBackDash(float dashForce)
    {
        rb.AddForce(Vector2.left * facingDirection * dashForce, ForceMode2D.Impulse);
    }
    public void EnemyForwardDash(float dashForce)
    {
        rb.AddForce(Vector2.right * facingDirection * dashForce, ForceMode2D.Impulse);
    }
}