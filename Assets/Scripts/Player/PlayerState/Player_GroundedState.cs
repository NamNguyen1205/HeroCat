using UnityEngine;

public class Player_GroundedState : PlayerState
{
    public Player_GroundedState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    override public void Update()
    {
        base.Update();

        if (player.input.Player.Jump.WasPressedThisFrame())
        {
            player.canDoubleJump = true;
            stateMachine.ChangeState(player.jumpState);
        }

        if (!player.isGrounded && rb.linearVelocityY < 0)
        {
            player.canDoubleJump = true;
            stateMachine.ChangeState(player.fallState);
        }

        if (player.input.Player.BasicAttack.WasPressedThisFrame())
            stateMachine.ChangeState(player.basicAttackState);
        //attack range state change
        if (player.input.Player.Aim.WasPerformedThisFrame())
            stateMachine.ChangeState(player.aimState);
    }
}
