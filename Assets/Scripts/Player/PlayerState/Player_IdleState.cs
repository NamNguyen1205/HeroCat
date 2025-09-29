using UnityEngine;

public class Player_IdleState : Player_GroundedState
{
    public Player_IdleState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, rb.linearVelocityY);
    }

    public override void Update()
    {
        base.Update();

        if (player.movement.x != 0 && player.isGrounded)
            stateMachine.ChangeState(player.moveState);
    }

}
