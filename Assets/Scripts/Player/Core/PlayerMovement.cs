using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private LayerMask layerMask;

    public int facingDirection { get; private set; } = 1;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rollForce;
    [SerializeField] private float knockbackForce;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(1.5f, 0.1f);
    public bool isGrounded
    {
        get
        {
            if (groundCheck == null)
            {
                Debug.LogWarning("Ground check transform is not assigned.");
                return false;
            }

            layerMask = LayerMask.GetMask("Ground");
            return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, layerMask) != null;
        }
    }

    public float linearVelocityY => rb.linearVelocityY;
    public float MoveSpeed => moveSpeed;
    public float JumpForce => jumpForce;
    public bool IsGrounded => isGrounded;
    public float RollForce => rollForce;
    public float KnockbackForce => knockbackForce;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayerMove(Vector2 direction)
    {
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);
    }
    public void PlayerStopMove()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }
    public void PlayerJump(float jumpForce)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public void PlayerFlip(float direction)
    {
        Vector3 scale = transform.localScale;
        if (direction > 0.01f)
        {
            facingDirection = 1;
            scale.x = Mathf.Abs(scale.x);
        }
        else if (direction < -0.01f)
        {
            facingDirection = -1;
            scale.x = -Mathf.Abs(-scale.x);
        }
        transform.localScale = scale;
    }
    public void PlayerRoll(float rollForce)
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        rb.AddForce(Vector2.right * rollForce, ForceMode2D.Impulse);
    }
    public void PlayerKnockBack(float knockbackForce)
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        rb.AddForce(Vector2.right * knockbackForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}