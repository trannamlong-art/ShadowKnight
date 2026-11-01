using UnityEngine;

public class PlayerStateRun : PlayerState
{
    public PlayerStateRun(PlayerController player) : base(player)
    {

    }

    public override void EnterState()
    {
        // Code to execute when entering the run state
        player.Animation.SetAnimationState("Run");
    }
    public override void UpdateState()
    {
        player.Movement.PlayerFlip(player.Input.moveInput.x);
        if (Mathf.Abs(player.Input.moveInput.x) <= 0.01f)
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
        if (player.Input.jumpInput && player.Movement.IsGrounded)
        {
            player.ChangeState(new PlayerStateJump(player));
            return;
        }
        if (player.Movement.linearVelocityY < 0 && player.Movement.IsGrounded == false)
        {
            player.ChangeState(new PlayerStateFall(player));
            return;
        }
        if (player.Input.attackInput && player.Combat.TrySpendStamina(player.Combat.AttackStaminaCost))
        {
            player.ChangeState(new PlayerStateAttack(player, 0));
            return;
        }
        if (player.Input.heavyAttackInput && player.Combat.TrySpendStamina(player.Combat.HeavyAttackStaminaCost))
        {
            player.ChangeState(new PlayerStateHeavyAttack(player, 0));
            return;
        }
        if (player.Input.rollingInput && player.Combat.TrySpendStamina(player.Combat.RollStaminaCost))
        {
            player.ChangeState(new PlayerStateRoll(player));
            return;
        }
        if (player.Input.healingInput && player.Health.CurrentHealth < player.Health.MaxHealth && player.Inventory.TryUseHealPotion())
        {
            player.ChangeState(new PlayerStateHeal(player));
            return;
        }
        if (player.Input.skillInput && player.Combat.SkillCooldownReset())
        {
            player.ChangeState(new PlayerStateSkill(player));
            return;
        }
    }

    public override void FixedUpdateState()
    {
        player.Movement.PlayerMove(player.Input.moveInput);

    }
    public override void ExitState()
    {
        // Code to execute when exiting the run state
    }
}
