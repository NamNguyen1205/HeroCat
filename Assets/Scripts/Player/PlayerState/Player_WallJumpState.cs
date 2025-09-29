using UnityEngine;

public class Player_WallJumpState : PlayerState
{
    public Player_WallJumpState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.wallJumpTimeDuration;
        player.Flip();

        // Apply wall jump force
        rb.linearVelocity = new Vector2(player.facingDirection * player.wallJumpForce.x, player.wallJumpForce.y);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            if(rb.linearVelocityY < 0)
                stateMachine.ChangeState(player.fallState);
            if(player.input.Player.Jump.WasPressedThisFrame()) // Double jump
            {
                player.canDoubleJump = false;
                stateMachine.ChangeState(player.jumpState);
            }
            
        }
    }
}
