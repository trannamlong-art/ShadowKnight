using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState { get; private set; }
    public Playerinput Input { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerAnimation Animation { get; private set; }
    public PlayerCombat Combat { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public PlayerHealth Health { get; private set; }
    public PlayerRespawn Respawn { get; private set; }
    public PlayerAudio Audio { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Input = GetComponent<Playerinput>();
        Movement = GetComponent<PlayerMovement>();
        Animation = GetComponentInChildren<PlayerAnimation>();
        Combat = GetComponent<PlayerCombat>();
        Inventory = GetComponent<PlayerInventory>();
        Health = GetComponent<PlayerHealth>();
        Respawn = GetComponent<PlayerRespawn>();
        Audio = GetComponent<PlayerAudio>();
    }
    private void Start()
    {
        ChangeState(new PlayerStateIdle(this));
    }

    // Update is called once per frame
    private void Update()
    {
        Input.InputActive();
        currentState?.UpdateState();
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState();
    }
    public void ChangeState(PlayerState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.EnterState();
        }
    }

    public void NextAttack()
    {
        if (currentState is PlayerStateAttack attackState)
        {
            attackState.QueueNextAttack();
        }
    }
    public void NextHeavyAttack()
    {
        if (currentState is PlayerStateHeavyAttack heavyAttackState)
        {
            heavyAttackState.QueueNextHeavyAttack();
        }
    }
}
