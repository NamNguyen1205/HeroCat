using UnityEngine;

public class Player_AimState : PlayerState
{
    public Player_AimState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        skillManager.skill_NaCaoSu.EnableDots(true);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(0, rb.linearVelocityY);

        Vector2 dirToMouse = DirectionMouse();

        skillManager.skill_NaCaoSu.PredictTrajectory(dirToMouse);
        skillManager.skill_NaCaoSu.ConfirmedDirection(dirToMouse);


        if (player.input.Player.Aim.WasReleasedThisFrame())
            stateMachine.ChangeState(player.idleState);

        if (player.input.Player.BasicAttack.WasPerformedThisFrame())
            PerformRangeAttack();
    }

    private void PerformRangeAttack()
    {
        bool isOnCooldown = skillManager.skill_NaCaoSu.OnCooldown();
        if (isOnCooldown)
            return;
            
        anim.SetTrigger("rangeAttack");
        //perform skill
        skillManager.skill_NaCaoSu.Bullet();
    }

    private Vector2 DirectionMouse()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - playerPosition;

        return direction.normalized;
    }

    public override void Exit()
    {
        base.Exit();
        skillManager.skill_NaCaoSu.EnableDots(false);
    }
}
