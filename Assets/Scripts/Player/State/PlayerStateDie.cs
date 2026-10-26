using UnityEngine;

public class PlayerStateDie : PlayerState
{
    public PlayerStateDie(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        // Code to execute when entering the die state
        player.Movement.PlayerStopMove();
        player.Input.DisableButton(true);
        player.Animation.SetAnimationState("Die");
    }
    public override void UpdateState()
    {
        // Code to execute during the die state update


    }
    public override void ExitState()
    {
        // Code to execute when exiting the die state
    }
}