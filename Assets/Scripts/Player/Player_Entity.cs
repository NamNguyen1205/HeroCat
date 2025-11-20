using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Entity : Entity
{
    private UI ui;
    public PlayerInputControll input { get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Player_JumpState jumpState { get; private set; }
    public Player_FallState fallState { get; private set; }
    public Player_WallSlideState wallSlideState { get; private set; }
    public Player_WallJumpState wallJumpState { get; private set; }
    public Player_DashState dashState { get; private set; }
    public Player_BasicAttackState basicAttackState { get; private set; }
    public Player_KnockBackState knockBackState { get; private set; }
    public Player_JumpAttackState jumpAttackState { get; private set; }
    public Player_AimState aimState { get; private set; }
    //public Player_RangeAttackState rangeAttackState { get; private set; }

    public Player_SoundSfx player_SoundSfx {get; private set; }


    public Vector2 movement { get; private set; }

    [Header("Attack Details")]
    public float comboAttackResetTime = 0.5f;

    [Header("Jump Details")]
    public float jumpForce;
    public float jumpMoveSpeed = 2.5f;
    public bool canDoubleJump;
    public bool canJumpNextToWall = false;
    [Header("Dash Details")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    [Header("Wall Slide/Jump Details")]
    public float wallSlideSpeed = 2f;
    public float wallSlideDownSpeed = 3f;
    public Vector2 wallJumpForce = new Vector2(5f, 10f);
    public float wallJumpTimeDuration = 1f;
    public bool isWallSlide;

    public Player_SkillManager skillManager;

    protected override void Awake()
    {
        base.Awake();
        skillManager = GetComponent<Player_SkillManager>();
        input = new PlayerInputControll();

        idleState = new Player_IdleState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
        jumpState = new Player_JumpState(this, stateMachine, "jump");
        fallState = new Player_FallState(this, stateMachine, "fall");
        wallSlideState = new Player_WallSlideState(this, stateMachine, "wallSlide");
        wallJumpState = new Player_WallJumpState(this, stateMachine, "jump");
        dashState = new Player_DashState(this, stateMachine, "dash");
        basicAttackState = new Player_BasicAttackState(this, stateMachine, "basicAttack");
        knockBackState = new Player_KnockBackState(this, stateMachine, "knockback");
        jumpAttackState = new Player_JumpAttackState(this, stateMachine, "jumpAttack");
        aimState = new Player_AimState(this, stateMachine, "aim");
        //rangeAttackState = new Player_RangeAttackState(this, stateMachine, "rangeAttack");
        player_SoundSfx = GetComponent<Player_SoundSfx>();
        ui = FindFirstObjectByType<UI>();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => movement = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    protected override void Start()
    {
        stateMachine.Initialize(idleState);
    }

    public override void EntityDeath()
    {
        anim.SetTrigger("death");
        Time.timeScale = 0;
    }
}
