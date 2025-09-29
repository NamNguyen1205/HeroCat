using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public Entity_Health entity_Health;
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public SpriteRenderer sr{ get; private set; }

    [Header("Movement Details")]
    public float moveSpeed = 5;
    protected bool isFacingRight = true;
    public float facingDirection => isFacingRight ? 1 : -1;
    [Header("Attack Details")]
    public Vector2[] attackVelocities;
    [Header("KnockBack Details")]
    private Coroutine knockbackCo;
    public bool isKnockBack = false;

    [Header("Ground Check")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected float groundCheckDis = 0.2f;
    public bool isGrounded;

    [Header("Wall Check")]
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected LayerMask whatIsWall;
    [SerializeField] protected float wallCheckDis = 0.2f;
    public bool isWall;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        stateMachine = new StateMachine();
        sr = GetComponentInChildren<SpriteRenderer>();
        entity_Health = GetComponent<Entity_Health>();
    }

    protected virtual void Start()
    {
    }

    public void CallAnimationTrigger()
    {
        stateMachine.currentState.CallTrigger();
    }

    protected virtual void Update()
    {
        HandleColliderDetect();
        stateMachine.UpdateActiveState();
    }

    public void PerformKnockBack(Vector2 knockbackPower, float knockbackDuration)
    {
        if (knockbackCo != null)
            StopCoroutine(knockbackCo);

        knockbackCo = StartCoroutine(KnockBackCo(knockbackPower, knockbackDuration));
    }

    private IEnumerator KnockBackCo(Vector2 knockbackPower, float knockbackDuration)
    {
        isKnockBack = true;
        rb.linearVelocity = knockbackPower;

        yield return new WaitForSeconds(knockbackDuration);

        isKnockBack = false;
        rb.linearVelocity = Vector2.zero;
    }

    protected virtual void HandleColliderDetect()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDis, whatIsGround);
        isWall = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDis, whatIsWall);
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }


    public void HandleFlip(float xVelocity)
    {
        if (xVelocity > 0 && !isFacingRight)
            Flip();
        if (xVelocity < 0 && isFacingRight)
            Flip();
    }

    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDis);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * wallCheckDis * facingDirection);
    }
}
