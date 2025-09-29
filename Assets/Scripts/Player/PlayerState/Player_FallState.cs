using UnityEngine;

public class Player_FallState : Player_InAirState
{
    public Player_FallState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.isGrounded && rb.linearVelocityY < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
            
         
    }
}
