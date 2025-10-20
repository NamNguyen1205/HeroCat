using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    private Transform player;

    private float lastTimeDetectedPlayer;
    public Enemy_BattleState(Enemy_Entity enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player ??= enemy.DetectPlayer().transform;

        if (player == null)
        {
            enemy.Flip();
            player ??= enemy.DetectPlayer().transform;
            if (player == null)
                enemy.FindPlayer();
        }
            

    }

    public override void Update()
    {
        base.Update();

        if (enemy.DetectPlayer())
            UpdateBattleTime();
            
        anim.SetFloat("xVelocity", rb.linearVelocityX);


        if (BattleIsOver())
            stateMachine.ChangeState(enemy.idleState);

        if (enemy.isWall)
        {
            FaceToPlayerAgain();
            enemy.SetVelocity(0, rb.linearVelocityY);
        }

        if (IsPlayerInAttackRange() && enemy.DetectPlayer())
            stateMachine.ChangeState(enemy.attackState);
        else if(!enemy.isWall)
            enemy.SetVelocity(enemy.battleMoveSpeed * DirectionToPlayer() * enemy.slowdownSpeed, rb.linearVelocityY);
    }

    private void FaceToPlayerAgain()
    {
        if (enemy.transform.position.x > player.position.x && enemy.facingDirection != -1)
            enemy.Flip();
        if (enemy.transform.position.x < player.position.x && enemy.facingDirection != 1)
            enemy.Flip();
    }

    private float DirectionToPlayer()
    {
        if (player == null)
            return 0;

        return enemy.transform.position.x > player.position.x ? -1 : 1;
    }
    
    private void UpdateBattleTime() => lastTimeDetectedPlayer = Time.time;
    private bool BattleIsOver() => Time.time > lastTimeDetectedPlayer + enemy.battleDuration;
    private bool IsPlayerInAttackRange()
    {
        if (player == null)
            return false;
        return Mathf.Abs(player.position.x - enemy.transform.position.x) <= enemy.attackRange;
    } 
    
}
