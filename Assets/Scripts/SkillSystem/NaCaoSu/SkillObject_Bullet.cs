using UnityEngine;

public class SkillObject_Bullet : SkillObject_Base
{
    public virtual void SetUpBullet(Vector2 direction, float scaleDamage)
    {
        rb.linearVelocity = direction;
        this.scaleDamage = scaleDamage;

    }

    protected virtual void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            DamageEnemiesInRange(transform, scaleDamage);

        if(target.gameObject.layer != LayerMask.NameToLayer("Player"))
            Destroy(gameObject);
    }
}
