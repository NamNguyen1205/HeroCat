using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Player_JumpAttackState : PlayerState
{
    public Player_JumpAttackState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        if (player.isGrounded)
            player.SetVelocity(0, rb.linearVelocityY);

        if (isTriggerCalled && player.isWall)
            stateMachine.ChangeState(player.wallSlideState);

        if (isTriggerCalled)
                stateMachine.ChangeState(player.idleState);
    }
}
