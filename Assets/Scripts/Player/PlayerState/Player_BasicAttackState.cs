using UnityEngine;

public class Player_BasicAttackState : PlayerState
{
    private int comboIndex = 0;
    private float lastAttackTime = 0f;
    private int comboLimit = 3;

    public Player_BasicAttackState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //CheckResetCombo()
        CheckResetCombo();

        comboIndex++;

        anim.SetInteger("comboIndex", comboIndex);
        ApplyAttackVelocity();
    }

    public override void Update()
    {
        base.Update();

        //apply attack velocity




        if (isTriggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    private void ApplyAttackVelocity()
    {
        for (int i = 0; i < player.attackVelocities.Length; i++)
        {
            if (i != comboIndex - 1)
                continue;

            rb.linearVelocity = new Vector2(player.attackVelocities[i].x * player.facingDirection, player.attackVelocities[i].y);
        }
    }

    override public void Exit()
    {
        base.Exit();

        lastAttackTime = Time.time;
    }

    private void CheckResetCombo()
    {
        if (Time.time > lastAttackTime + player.comboAttackResetTime)
        {
            ResetCombo();
        }
        if(comboIndex >= comboLimit)
            ResetCombo();
    }
    
    private void ResetCombo()
    {
        comboIndex = 0;
    }

}
