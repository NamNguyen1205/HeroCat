using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy_Entity enemy;
    protected Entity_Health entityHealth;
    public EnemyState(Enemy_Entity enemy, StateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        this.enemy = enemy;
        anim = enemy.anim;
        rb = enemy.rb;
        entityHealth = enemy.entity_Health;
    }

    public override void Update()
    {
        base.Update();
        if (enemy.isKnockBack)
            stateMachine.ChangeState(enemy.knockBackState);
        if (enemy.isDead)
            stateMachine.ChangeState(enemy.deadState);
    }

}
