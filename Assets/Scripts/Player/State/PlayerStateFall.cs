using UnityEngine;

public class PlayerStateFall : PlayerState
{
    public PlayerStateFall(PlayerController player) : base(player)
    {

    }
    private bool hasLeftGround;
    public override void EnterState()
    {
        hasLeftGround = false;
        player.Animation.SetAnimationState("MidAir");
    }
    public override void UpdateState()
    {
        player.Animation.SetAnimationFallState(player.Movement.linearVelocityY);
        player.Movement.PlayerFlip(player.Input.moveInput.x);
        bool grounded = player.Movement.IsGrounded;
        if (!grounded)
        {
            hasLeftGround = true;
        }
        if (hasLeftGround && grounded)
        {
            player.ChangeState(new PlayerStateLand(player));
            return;
        }
    }
    public override void FixedUpdateState()
    {
        player.Movement.PlayerMove(player.Input.moveInput);
    }
    public override void ExitState()
    {
    }

}