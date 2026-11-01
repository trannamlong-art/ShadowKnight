using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(PlayerController player) : base(player)
    {

    }

    public override void EnterState()
    {
        player.Movement.PlayerMove(Vector2.zero);
        player.Animation.SetAnimationState("Idle");
    }
    public override void UpdateState()
    {
        // Code to execute during the idle state update
        if (Mathf.Abs(player.Input.moveInput.x) > 0.01f)
        {
            player.ChangeState(new PlayerStateRun(player));
            return;
        }
        if (player.Input.jumpInput && player.Movement.IsGrounded)
        {
            player.ChangeState(new PlayerStateJump(player));
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
    public override void ExitState()
    {
        // Code to execute when exiting the idle state
    }
}
