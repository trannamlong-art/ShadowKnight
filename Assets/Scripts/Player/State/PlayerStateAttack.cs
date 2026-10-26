using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    private bool nextAttackQueued;
    private bool nextAttacking;
    private int attackIndex;
    public PlayerStateAttack(PlayerController player, int attackIndex) : base(player)
    {
        this.attackIndex = attackIndex;

    }

    public override void EnterState()
    {
        // Code to execute when entering the attack state
        player.Movement.PlayerStopMove();
        player.Animation.SetAnimationAttackState(attackIndex);
    }
    public override void UpdateState()
    {
        // Code to execute during the attack state update
        if (player.Input.attackInput && !nextAttacking)
        {
            nextAttacking = true;
        }


        if (nextAttackQueued && nextAttacking && player.Combat.TrySpendStamina(player.Combat.AttackStaminaCost))
        {
            nextAttackQueued = false;
            player.ChangeState(new PlayerStateAttack(player, attackIndex + 1));
            return;
        }

        if (player.Animation.IsAnimationFinished())
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
    }
    public void QueueNextAttack()
    {
        nextAttackQueued = true;
    }
    public override void ExitState()
    {
        // Code to execute when exiting the attack state
    }
}