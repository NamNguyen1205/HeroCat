using Unity.VisualScripting;
using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    private Transform player;
    private float playerPosX;
    private float enemyPosX;
    private float lastTimeDetectedPlayer;
    public Enemy_BattleState(Enemy_Entity enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player ??= enemy.DetectPlayer().transform;

    }

    public override void Update()
    {
        base.Update();

        if (enemy.DetectPlayer())
            lastTimeDetectedPlayer = Time.time;
        anim.SetFloat("xVelocity", rb.linearVelocityX);

        FlipToPlayer();
        //if (!IsPlayerInAttackRange() && )

        if (IsPlayerInAttackRange() && enemy.DetectPlayer())
            stateMachine.ChangeState(enemy.attackState);
        if (CanNotChasePlayer())
            stateMachine.ChangeState(enemy.idleState);

        if (!enemy.isWall && !enemy.isKnockBack)
            enemy.SetVelocity(enemy.battleMoveSpeed * enemy.facingDirection, rb.linearVelocityY);
        if (enemy.isWall)
            enemy.SetVelocity(0, rb.linearVelocityY);


    }

    private void FlipToPlayer()
    {
        playerPosX = player.position.x;
        enemyPosX = enemy.transform.position.x;
        if (playerPosX < enemyPosX && enemy.facingDirection != -1)
            enemy.Flip();
        else if (playerPosX > enemyPosX && enemy.facingDirection != 1)
            enemy.Flip();
    }

    private bool CanNotChasePlayer() => Time.time > lastTimeDetectedPlayer + enemy.chasePlayerDuration;


    private bool IsPlayerInAttackRange() => Mathf.Abs(playerPosX - enemyPosX) <= enemy.attackRange;

    public override void Exit()
    {
        base.Exit();
        enemy.SetVelocity(0, rb.linearVelocityY);
    }
    
}
