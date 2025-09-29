using UnityEditor.Callbacks;
using UnityEngine;

public class Player_MoveState : Player_GroundedState
{
    public Player_MoveState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        player.SetVelocity(player.movement.x * player.moveSpeed, rb.linearVelocityY);

        base.Update();


        if (player.movement.x == 0)
            stateMachine.ChangeState(player.idleState);

        //check player move next to wall
        if (player.isWall && player.movement.x != 0)
            player.canJumpNextToWall = true;
            
        //khi di chuyen vao tuong va nhay thi ko bi bam tuong
        if (player.input.Player.Jump.WasPressedThisFrame() && player.canJumpNextToWall)
        {
            stateMachine.ChangeState(player.jumpState);
        }

        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
