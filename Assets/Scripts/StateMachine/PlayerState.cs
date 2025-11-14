using UnityEngine;

public class PlayerState : EntityState
{
    protected Player_Entity player;
    protected SpriteRenderer sr;
    protected Player_SkillManager skillManager;
    public PlayerState(Player_Entity player, StateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        this.player = player;

        anim = player.anim;
        rb = player.rb;
        sr = player.sr;
        skillManager = player.skillManager;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (player.input.Player.Dash.WasPressedThisFrame() && !skillManager.skill_Dash.OnCooldown())
        {
            if (stateMachine.currentState == player.wallSlideState)
                player.Flip();
            
            if(skillManager.skill_Dash.skillUpgradeType == SkillUpgradeType.DashAndBack)
            {
                skillManager.skill_Dash.CreateShadow(player.transform.position);
            }

            //use visual effect
            if(stateMachine.currentState is Player_GroundedState)
                VisualEffectManager.instance.StartDashEffect(player.transform.position, player.isFacingRight);
            stateMachine.ChangeState(player.dashState);
        }

        if (player.isKnockBack)
            stateMachine.ChangeState(player.knockBackState);
            
    }

}
