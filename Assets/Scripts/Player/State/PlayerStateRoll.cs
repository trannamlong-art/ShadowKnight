using UnityEngine;

public class PlayerStateRoll : PlayerState
{
    private int rollDirection;
    public PlayerStateRoll(PlayerController player) : base(player)
    {

    }

    public override void EnterState()
    {
        player.Animation.SetAnimationState("Roll");
        rollDirection = player.Movement.facingDirection;
        player.Movement.PlayerRoll(player.Movement.RollForce * rollDirection);
    }
    public override void UpdateState()
    {
        player.Input.DisableButton(!player.Animation.IsAnimationFinished());
        player.Combat.DisableEnemyCollisions(!player.Animation.IsAnimationFinished());


        if (player.Animation.IsAnimationFinished() && player.Input.moveInput != Vector2.zero)
        {
            player.ChangeState(new PlayerStateRun(player));
            return;
        }
        if (player.Animation.IsAnimationFinished())
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
    }
    public override void FixedUpdateState()
    {

    }
    public override void ExitState()
    {
        // Code to execute when exiting the roll state
    }
}