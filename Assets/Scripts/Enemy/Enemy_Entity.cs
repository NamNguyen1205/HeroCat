using System.Collections;
using UnityEngine;

public class Enemy_Entity : Entity
{
    public Enemy_IdleState idleState { get; protected set; }
    public Enemy_MoveState moveState { get; protected set; }
    public Enemy_BattleState battleState { get; protected set; }
    public Enemy_AttackState attackState { get; protected set; }
    public Enemy_KnockBackState knockBackState { get; protected set; }
    public Enemy_DeadState deadState { get; protected set; }
    

    public float idleTime = 2f;
    [Header("Detected Player")]
    public float playerCheckDistance = 10f;
    public LayerMask whatIsPlayer;
    public Transform playerCheck;
    public bool isDetectedPlayer = false;
    [Header("Battle Details")]
    public float battleMoveSpeed = 3f;
    public float attackRange = 2f;
    public float chasePlayerDuration = 5f;
    public float moveBackDistance = 0.3f;
    public Vector2 moveBackPower;


    protected override void HandleColliderDetect()
    {
        base.HandleColliderDetect();

        // isDetectedPlayer = Physics2D.Raycast(playerCheck.position, Vector2.right * facingDirection, playerCheckDistance, whatIsPlayer);
    }

    public override void EntityDeath()
    {
        base.EntityDeath();
        if (isDead)
            StartCoroutine(DeathCo());

    }

    private IEnumerator DeathCo()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    public RaycastHit2D DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCheck.position, Vector2.right * facingDirection, playerCheckDistance, whatIsPlayer | whatIsGround);
        if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
            return default;

        return hit;
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + Vector3.right * facingDirection * playerCheckDistance);
        base.OnDrawGizmos();
    }
}
