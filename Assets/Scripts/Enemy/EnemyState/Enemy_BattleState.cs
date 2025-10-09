using System.Collections;
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

        if(player != null)
            MoveAwayFromPlayer();
    }

    public override void Update()
    {
        base.Update();
        if(player != null)
            MoveAwayFromPlayer();

        if (enemy.DetectPlayer())
            lastTimeDetectedPlayer = Time.time;
        anim.SetFloat("xVelocity", rb.linearVelocityX);

        FlipToPlayer();

        if (CanNotChasePlayer())
            stateMachine.ChangeState(enemy.idleState);

        if (IsPlayerInAttackRange() && enemy.DetectPlayer())
            stateMachine.ChangeState(enemy.attackState);
        else  
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

    private void MoveAwayFromPlayer()
    {

        float distance = Mathf.Abs(player.position.x - enemy.transform.position.x);

        if (distance < enemy.moveBackDistance)
        {
            if (DirectionToPlayer() == -1)
                rb.linearVelocity = new Vector2(enemy.moveBackPower.x * - DirectionToPlayer(), enemy.moveBackPower.y);
            if (DirectionToPlayer() == 1)
                rb.linearVelocity = new Vector2(enemy.moveBackPower.x * - DirectionToPlayer(), enemy.moveBackPower.y);
        }
    }

    private float DirectionToPlayer()
    {
        if (player == null)
            return 0;

        return enemy.transform.position.x > player.position.x ? -1 : 1;
    }

    private bool CanNotChasePlayer() => Time.time > lastTimeDetectedPlayer + enemy.chasePlayerDuration;


    private bool IsPlayerInAttackRange() => Mathf.Abs(playerPosX - enemyPosX) <= enemy.attackRange;

    public override void Exit()
    {
        base.Exit();
    }
    
}
