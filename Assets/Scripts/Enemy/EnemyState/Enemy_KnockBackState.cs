using UnityEngine;

public class Enemy_KnockBackState : EnemyState
{
    public Enemy_KnockBackState(Enemy_Entity enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (!enemy.isKnockBack)
            stateMachine.ChangeState(enemy.battleState);
    }

}
