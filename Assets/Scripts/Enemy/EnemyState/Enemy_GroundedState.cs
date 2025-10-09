using UnityEngine;

public class Enemy_GroundedState : EnemyState
{
    private float healthBefore;
    private float currentHealth;
    public Enemy_GroundedState(Enemy_Entity enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
        healthBefore = entityHealth.GetCurrentHealth();
    }
    public override void Enter()
    {
        base.Enter();
        currentHealth = entityHealth.GetCurrentHealth();

    }

    public override void Update()
    {
        base.Update();

        if (enemy.DetectPlayer())
            stateMachine.ChangeState(enemy.battleState);
        //bi attack chuyen sao battle state
        if (BeAttacked())
            stateMachine.ChangeState(enemy.battleState);


    }
    
    private bool BeAttacked()
    {
        if (currentHealth < healthBefore)
        {
            healthBefore = currentHealth;
            return true;
        }
        return false;
    }
}
