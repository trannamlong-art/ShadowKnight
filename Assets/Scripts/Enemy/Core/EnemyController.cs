using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyState currentState { get; private set; }
    public EnemyData Data;
    public EnemyAnimation Animation { get; private set; }
    public EnemyDetection Detection { get; private set; }
    public EnemyMovement Movement { get; private set; }
    public EnemyCombat Combat { get; private set; }
    public EnemyHealth Health { get; private set; }
    public EnemySound Audio { get; private set; }

    public SkeletonShield Shield { get; private set; }
    public UndeadSummon Summon { get; private set; }

    public UIManager GameManager { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Animation = GetComponent<EnemyAnimation>();
        Detection = GetComponent<EnemyDetection>();
        Movement = GetComponent<EnemyMovement>();
        Combat = GetComponent<EnemyCombat>();
        Health = GetComponent<EnemyHealth>();
        Audio = GetComponent<EnemySound>();

        Shield = GetComponent<SkeletonShield>();
        Summon = GetComponent<UndeadSummon>();
        GameManager = FindAnyObjectByType<UIManager>();
    }
    void Start()
    {
        ChangeState(new EnemyStateIdle(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
    }
    void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }
    public void ChangeState(EnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    public void ResetEnemy()
    {
        // Reset the enemy's position and scale to their initial values
        Movement.transform.position = Movement.InitialPosition;
        Movement.transform.localScale = Movement.InitialScale;

        Health.RestoreFullHealth();
        gameObject.tag = "Enemy";

        if (Summon != null)
        {
            Summon.DisableSummon();
            Summon.CannotSummon();
        }

        // Reset the enemy's state to idle
        gameObject.SetActive(true);
        ChangeState(new EnemyStateIdle(this));
    }
}
