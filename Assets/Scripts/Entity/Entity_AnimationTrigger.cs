using UnityEngine;

public class Entity_AnimationTrigger : MonoBehaviour
{
    Entity entity;
    Entity_Combat combat;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
        combat = GetComponentInParent<Entity_Combat>();
    }

    public void AnimationTrigger()
    {
        entity.CallAnimationTrigger();
    }

    public void AttackTrigger()
    {
        combat.PerformAttack();
    }
    
}
