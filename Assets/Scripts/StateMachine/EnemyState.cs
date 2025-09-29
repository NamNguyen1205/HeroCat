using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy_Entity enemy;
    public EnemyState(Enemy_Entity enemy, StateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        this.enemy = enemy;
        anim = enemy.anim;
        rb = enemy.rb;
    }

    public override void Update()
    {
        base.Update();
        if (enemy.isKnockBack)
            stateMachine.ChangeState(enemy.knockBackState);
    }

}
