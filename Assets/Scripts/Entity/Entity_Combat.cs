using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    private Entity_SoundSFX soundSfx;
    [SerializeField] private Transform target;
    private Entity_VFX entityVfx;
    private Entity_Stat entityStat;
    [SerializeField] private LayerMask whatIsTarget;

    [SerializeField] private float targetRaidus = 2f;
    [SerializeField] private float damage = 10f;

    private void Awake()
    {
        entityVfx = GetComponent<Entity_VFX>();
        entityStat = GetComponent<Entity_Stat>();
        soundSfx = GetComponent<Entity_SoundSFX>();

    }

    public void PerformAttack()
    {
        bool GotHit = false;
        //check attack ai
        foreach (var target in TargetColliders())
        {
            //damageable tu collider bi attack
            IDamageable damageable = target.GetComponent<IDamageable>();

            damage = entityStat.GetPhysicalDamage();

            GotHit = damageable.TakeDamage(damage, transform, ElementalType.None);

            if (GotHit)
            {
                soundSfx?.PlayAttackSfx();
            }
        }
        
        if(GotHit == false)
        {
            soundSfx?.PlayAttackMissSfx();
        }
        
    }

    private Collider2D[] TargetColliders()
    {
        return Physics2D.OverlapCircleAll(target.position, targetRaidus, whatIsTarget);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, targetRaidus);
    }
}
