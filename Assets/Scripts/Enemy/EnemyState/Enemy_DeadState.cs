using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    private Collider2D col;
    public Enemy_DeadState(Enemy_Entity enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
        col = enemy.GetComponent<Collider2D>();
    }

    public override void Enter()
    {
        base.Enter();
        col.enabled = false;

        rb.gravityScale = 12;
        enemy.SetVelocity(rb.linearVelocityX, 17);

        //can not change state
        stateMachine.CanNotChangeState();
    }


}
