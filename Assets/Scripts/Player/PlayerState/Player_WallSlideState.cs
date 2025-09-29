using System.Collections;
using UnityEngine;

public class Player_WallSlideState : PlayerState
{
    public Player_WallSlideState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        player.canDoubleJump = true;
        //player.Flip();
        sr.flipX = true;
    }

    public override void Update()
    {
        base.Update();
        // Handle wall slide movement
        rb.linearVelocity = new Vector2(player.movement.x, -player.wallSlideSpeed);

        //wall jump
        if (player.input.Player.Jump.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.wallJumpState);
        }
        if(!player.isWall)
            stateMachine.ChangeState(player.fallState);
        //change idle state when fall onto ground
            if (player.isGrounded)
                stateMachine.ChangeState(player.idleState);
        //slide down faster when hold down
        if (player.movement.y < 0)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, -player.wallSlideDownSpeed);

    }

    private IEnumerator DelayChangeFallState()
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(player.fallState);
    }

    public override void Exit()
    {
        base.Exit();
        sr.flipX = false;
    }

}
