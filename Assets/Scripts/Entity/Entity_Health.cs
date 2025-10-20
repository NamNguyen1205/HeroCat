using System.Collections;
using UnityEngine;

public class Entity_Health : MonoBehaviour, IDamageable
{
    private Entity_VFX vfx;
    protected Entity entity;
    protected Entity_Stat entityStat;
    // [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [Header("KnockBack Details")]
    [SerializeField] private Vector2 knockBackPower = new Vector2(1.5f, 1.5f);
    [SerializeField] private Vector2 heavyKnockBackPower = new Vector2(7f, 7f);
    [SerializeField] private float knockbackDuration = 0.2f;
    [SerializeField] private float heavyKnockbackDuration = 0.5f;

    private void Awake()
    {
        vfx = GetComponent<Entity_VFX>();
        entity = GetComponent<Entity>();
        entityStat = GetComponent<Entity_Stat>();
        currentHealth = entityStat.GetMaxHealth();

    }
    //tranform là của entity gây sát thương
    public bool TakeDamage(float damage, Transform damageDealer, ElementalType elemental)
    {

        Vector2 knockbackVelocity = CalculateKnockBack(damage, damageDealer);
        float knockbackDuration = CheckKnockBackDuration(damage);


        vfx?.PlayOnTakeDamageVfx();
        vfx.CreateOnHitVfxPrefab();
        
        entity?.PerformKnockBack(knockbackVelocity, knockbackDuration);

        ReduceHp(damage);


        return true;
    }


    //if damage >= 35% maxhealth => heavyKnockback
    private bool CheckDamageKnockBack(float damage) => damage / entityStat.GetMaxHealth() >= 0.3f;
    private float CheckKnockBackDuration(float damage) => CheckDamageKnockBack(damage) ? heavyKnockbackDuration : knockbackDuration;

    //Calculate knockback direction and heavy knockbakc or light knockback
    private Vector2 CalculateKnockBack(float damage, Transform damageDealer)
    {
        float knockbackDirection = transform.position.x > damageDealer.position.x ? 1 : -1;

        Vector2 knockbackVelocity = CheckDamageKnockBack(damage) ? heavyKnockBackPower : knockBackPower;

        knockbackVelocity.x = knockbackDirection * knockbackVelocity.x;

        return knockbackVelocity;
    }

    private void ReduceHp(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    private void Die()
    {
        entity.isDead = true;
        entity.EntityDeath();
    }

    //UI health bar 
    public float GetMaxHealth() => entityStat.GetMaxHealth();
    public float GetCurrentHealth() => currentHealth;

    
}
