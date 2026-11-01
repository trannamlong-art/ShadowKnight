using UnityEngine;

public class PlayerStateJump : PlayerState
{
    public PlayerStateJump(PlayerController player) : base(player)
    {

    }
    private bool hasLeftGround;
    public override void EnterState()
    {
        hasLeftGround = false;
        player.Movement.PlayerJump(player.Movement.JumpForce);
        player.Animation.SetAnimationState("Jump");
    }
    public override void UpdateState()
    {
        // Code to execute during the jump state update
        player.Movement.PlayerFlip(player.Input.moveInput.x);
        bool grounded = player.Movement.IsGrounded;
        if (!grounded)
        {
            hasLeftGround = true;
        }
        // 

        if (player.Movement.linearVelocityY < -0.01f)
        {
            player.ChangeState(new PlayerStateFall(player));
            return;
        }
        if (hasLeftGround && grounded && player.Movement.linearVelocityY == 0)
        {
            player.ChangeState(new PlayerStateIdle(player));
            return;
        }
    }
    public override void FixedUpdateState()
    {
        // Code to execute during the jump state fixed update
        player.Movement.PlayerMove(player.Input.moveInput);
    }
    public override void ExitState()
    {
        // Code to execute when exiting the jump state
    }
}