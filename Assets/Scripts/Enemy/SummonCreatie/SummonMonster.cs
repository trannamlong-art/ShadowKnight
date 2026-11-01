using Unity.VisualScripting;
using UnityEngine;

public class SummonMonster : MonoBehaviour
{
    private enum SummonState
    {
        Spawning,
        Idle,
        Die
    }
    private SummonState currentState;
    private Animator animator;
    private Transform playerTransform;
    [SerializeField] private float minAttackInterval = 3f;
    [SerializeField] private float maxAttackInterval = 10f;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDamage;
    [SerializeField] private float moveSpeed;

    private float nextAttackTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
    }
    private void OnEnable()
    {
        nextAttackTime = Time.time + Random.Range(minAttackInterval, maxAttackInterval);
        ChangeState(SummonState.Spawning);
    }

    private void Update()
    {
        switch (currentState)
        {
            case SummonState.Spawning:
                if (IsAnimationFinished("Spawning"))
                {
                    ChangeState(SummonState.Idle);
                }
                break;
            case SummonState.Idle:
                if (Time.time >= nextAttackTime)
                {
                    if (transform.parent != null) transform.SetParent(null);

                    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
                    SummonAttack();
                }
                break;
            case SummonState.Die:
                if (IsAnimationFinished("Die"))
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }
    private void ChangeState(SummonState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case SummonState.Spawning:
                animator.Play("Spawning", 0, 0f);
                break;
            case SummonState.Idle:
                animator.Play("Idle", 0, 0f);
                break;
            case SummonState.Die:
                animator.Play("Die", 0, 0f);
                break;
        }
    }
    private void SummonAttack()
    {
        Collider2D[] summonHit = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Player"));

        foreach (Collider2D summon in summonHit)
        {
            PlayerHealth playerHealth = summon.GetComponent<PlayerHealth>();
            Transform transform = GetComponent<Transform>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage, transform);
                TakeHit();
                return;
            }
        }
    }
    private bool IsAnimationFinished(string name)
    {
        var state = animator.GetCurrentAnimatorStateInfo(0);

        return state.IsName(name) && state.normalizedTime >= 1f;
    }
    public void TakeHit()
    {
        if (currentState == SummonState.Die) return;
        ChangeState(SummonState.Die);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
