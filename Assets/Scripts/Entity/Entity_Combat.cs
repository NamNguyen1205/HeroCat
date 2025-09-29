using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask whatIsTarget;

    [SerializeField] private float targetRaidus = 2f;
    [SerializeField] private float damage = 10f;

    private void Awake()
    {
        
    }

    public void PerformAttack()
    {
        //check attack ai
        foreach (var target in TargetColliders())
        {
            //damageable tu collider bi attack
            IDamageable damageable = target.GetComponent<IDamageable>();
            

            damageable.TakeDamage(damage, transform);
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
