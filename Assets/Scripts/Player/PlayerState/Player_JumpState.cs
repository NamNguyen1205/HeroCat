using UnityEngine;

public class Player_JumpState : Player_InAirState
{

    public Player_JumpState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        rb.linearVelocity = new Vector2(rb.linearVelocityX, player.jumpForce);


    }
    public override void Update()
    {
        base.Update();

        //reset canJumpNextToWall when player is falling
        if (rb.linearVelocityY < 0)
            player.canJumpNextToWall = false;

        //change to fall state if player is falling
        if (rb.linearVelocityY < 0)
            stateMachine.ChangeState(player.fallState);

    }
}
