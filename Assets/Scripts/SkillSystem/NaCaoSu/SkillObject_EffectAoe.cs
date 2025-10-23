using System.Collections;
using UnityEngine;

public class SkillObject_EffectAoe : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float checkRadius;
    [SerializeField] private Transform checkCenter;
    [SerializeField] SkillDataSO skillData;
    protected Entity_Stat playerStat;
    protected Player_Entity player;
    protected Entity_StatusEffect targetStatusEffect;
    protected float scaleDamage;
    private Coroutine effectCo;
    private float timer = 0;
    private float startTime = 0;
    protected ElementalType elementalType;

    private void Awake()
    {
        timer = Time.time;
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > startTime + skillData.duration)
            Destroy(gameObject);

        if (Time.time > timer + skillData.takeDamageTime)
        {
            ApplyEffectInArea();
            timer = Time.time;
        }
    }


    protected virtual void ApplyEffectInArea()
    {
        foreach (var target in CheckEnemiesAround())
        {
            IDamageable damageable = target.GetComponent<IDamageable>();

            float damage = playerStat.GetPhysicalDamage(scaleDamage);

            if (damageable == null)
                continue;

            bool gotHit = damageable.TakeDamage(damage / skillData.duration, player.transform, elementalType);
            target.GetComponent<Entity_StatusEffect>().ApplyElementalVfx(elementalType);
        }
        //hieu ung tung skill
    }

    public void GetSkillInfor(Player_Entity player, Entity_Stat playerStat, float scaleDamage)
    {
        this.player = player;
        this.playerStat = playerStat;
        this.scaleDamage = scaleDamage;
    }
    
    protected virtual Collider2D[] CheckEnemiesAround()
    {
        return Physics2D.OverlapCircleAll(checkCenter.position, checkRadius, whatIsEnemy);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkCenter.position, checkRadius);
    }
}
