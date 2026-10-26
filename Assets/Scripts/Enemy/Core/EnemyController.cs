using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyState currentState { get; private set; }
    public EnemyData Data;
    public EnemyAnimation Animation { get; private set; }
    public EnemyDetection Detection { get; private set; }
    public EnemyMovement Movement { get; private set; }
    public EnemyCombat Combat { get; private set; }

    public SkeletonShield Shield { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Animation = GetComponent<EnemyAnimation>();
        Detection = GetComponent<EnemyDetection>();
        Movement = GetComponent<EnemyMovement>();
        Combat = GetComponent<EnemyCombat>();

        Shield = GetComponent<SkeletonShield>();
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
}
