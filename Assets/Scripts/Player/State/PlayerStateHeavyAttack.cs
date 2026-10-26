using UnityEngine;

public class PlayerStateHeavyAttack : PlayerState
{
    private bool nextHeavyAttackQueued;
    private bool nextHeavyAttacking;
    private int heavyAttackIndex;
    public PlayerStateHeavyAttack(PlayerController player, int heavyAttackIndex) : base(player)
    {
        this.heavyAttackIndex = heavyAttackIndex;
    }

    public override void EnterState()
    {
        // Code to execute when entering the heavy attack state
        player.Movement.PlayerStopMove();
        player.Animation.SetAnimationHeavyAttackState(heavyAttackIndex);
    }
    public override void UpdateState()
    {
        // Code to execute during the heavy attack state update
        if (player.Input.heavyAttackInput && !nextHeavyAttacking)
        {
            nextHeavyAttacking = true;
        }

        if (nextHeavyAttackQueued && nextHeavyAttacking && player.Combat.TrySpendStamina(player.Combat.HeavyAttackStaminaCost))
        {
            nextHeavyAttackQueued = false;
            player.ChangeState(new PlayerStateHeavyAttack(player, heavyAttackIndex + 1));
            return;
        }
        if (player.Animation.IsAnimationFinished())
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
    }
    public void QueueNextHeavyAttack()
    {
        // Implement logic for queuing the next heavy attack if needed
        nextHeavyAttackQueued = true;
    }
    public override void ExitState()
    {
        // Code to execute when exiting the heavy attack state
    }
}