using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Player_DashState : PlayerState
{
    private float dashDirection;
    public Player_DashState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.dashDuration;
    }

    public override void Update()
    {
        base.Update();

        dashDirection = player.movement.x != 0 ? player.movement.x : player.facingDirection;
        player.SetVelocity(player.dashSpeed * dashDirection, 0);

        if (player.isWall)
            stateMachine.ChangeState(player.wallSlideState);


        if (stateTimer < 0f)
        {
            if (player.isGrounded)
                stateMachine.ChangeState(player.idleState);
            else
                stateMachine.ChangeState(player.fallState);

        }
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, 0);
    }

    
}
