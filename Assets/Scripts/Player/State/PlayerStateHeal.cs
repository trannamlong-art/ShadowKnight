using UnityEngine;

public class PlayerStateHeal : PlayerState
{
    public PlayerStateHeal(PlayerController player) : base(player)
    {

    }

    public override void EnterState()
    {
        // Code to execute when entering the state
        player.Animation.SetAnimationState("Heal");
        player.Input.DisableButton(true);
        player.Audio.PlayHealSound();
    }
    public override void UpdateState()
    {
        // Code to execute during the state update

        if (player.Animation.IsAnimationFinished())
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
    }
    public override void FixedUpdateState()
    {
        player.Movement.PlayerStopMove();
    }

    public override void ExitState()
    {
        // Code to execute when exiting the state
        player.Input.DisableButton(false);
    }
}