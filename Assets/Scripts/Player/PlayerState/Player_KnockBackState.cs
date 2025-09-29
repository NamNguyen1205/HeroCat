using UnityEngine;

public class Player_KnockBackState : PlayerState
{
    public Player_KnockBackState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (!player.isKnockBack)
            stateMachine.ChangeState(player.idleState);
    }
}
