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
        if (player.input.Player.Dash.WasPressedThisFrame())
        {
            if (stateMachine.currentState == player.wallSlideState)
                player.Flip();

            stateMachine.ChangeState(player.dashState);
        }

        if (player.isKnockBack)
            stateMachine.ChangeState(player.knockBackState);
            
    }

}
