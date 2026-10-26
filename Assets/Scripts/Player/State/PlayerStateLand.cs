using UnityEngine;

public class PlayerStateLand : PlayerState
{
    public PlayerStateLand(PlayerController player) : base(player)
    {

    }

    public override void EnterState()
    {
        // Code to execute when entering the land state
        player.Animation.SetAnimationState("Land");
    }
    public override void UpdateState()
    {
        // Code to execute during the land state update
        player.Movement.PlayerFlip(player.Input.moveInput.x);

        if (player.Animation.IsAnimationFinished())
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
    }
    public override void FixedUpdateState()
    {
        // Code to execute during the land state fixed update
        player.Movement.PlayerMove(player.Input.moveInput);
    }
    public override void ExitState()
    {
        // Code to execute when exiting the land state
    }
}