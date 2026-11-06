using UnityEngine;

public class PlayerStateHurt : PlayerState
{

    public PlayerStateHurt(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        // Code to execute when entering the hurt state
        player.Input.DisableButton(true);
        player.Animation.SetAnimationState("Hurt");
        player.Audio.PlayHurtSound();
    }
    public override void UpdateState()
    {
        // Code to execute during the hurt state update
        if (player.Animation.IsHurtFinished())
        {
            player.ChangeState(new PlayerStateIdle(player));
        }
    }
    public override void ExitState()
    {
        // Code to execute when exiting the hurt state
        player.Input.DisableButton(false);
    }
}