using UnityEngine;

public class PlayerStateSkill : PlayerState
{
    public PlayerStateSkill(PlayerController player) : base(player)
    {

    }

    public override void EnterState()
    {
        player.Movement.PlayerStopMove();
        player.Animation.SetAnimationState("Skill");
    }
    public override void UpdateState()
    {
        player.Movement.PlayerStopMove();
        if (player.Animation.IsAnimationFinished())
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
    }
    public override void ExitState()
    {

    }
}