using UnityEngine;

public class Player_InAirState : PlayerState
{
    public Player_InAirState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
       
    }
    public override void Enter()
    {
        base.Enter();

        
    }

    public override void Update()
    {
        base.Update();

        // Handle horizontal movement while in the air
        if (player.movement.x != 0)
            player.SetVelocity(player.movement.x * player.jumpMoveSpeed, rb.linearVelocityY);
            
        if (player.input.Player.Jump.WasPressedThisFrame() && player.canDoubleJump) // Double jump
        {
            player.canDoubleJump = false;
            stateMachine.ChangeState(player.jumpState);
        }
       
        if (player.isWall && !player.canJumpNextToWall)
            stateMachine.ChangeState(player.wallSlideState);
        
    }

}
