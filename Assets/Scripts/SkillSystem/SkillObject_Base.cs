using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class SkillObject_Base : MonoBehaviour
{
    [SerializeField] protected LayerMask whatIsEnemy;
    [SerializeField] protected Transform targetCheck;
    [SerializeField] protected float checkRadius;
    protected Rigidbody2D rb;
    protected Player_Entity player;
    protected Entity_Stat playerStat;
    protected float scaleDamage;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<Player_Entity>();
        playerStat = player.gameObject.GetComponent<Entity_Stat>();
    }

    protected virtual void DamageEnemiesInRange(Transform t, float scaleDamage)
    {
        foreach(var target in CheckEnemiesAround(t))
        {
            IDamageable damageable = target.GetComponent<IDamageable>();

            //tính toán damage từ player stat
            float damage = playerStat.GetPhysicalDamage(scaleDamage);

            if (damageable == null)
                continue;

            bool gotHit = damageable.TakeDamage(damage, player.transform, ElementalType.None);
        }
    }

    protected virtual Collider2D[] CheckEnemiesAround(Transform target)
    {
        return Physics2D.OverlapCircleAll(target.position, checkRadius, whatIsEnemy);
    }
    
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, checkRadius);
    }
}
