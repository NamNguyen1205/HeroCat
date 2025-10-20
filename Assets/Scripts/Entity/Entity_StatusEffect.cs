using UnityEngine;
using UnityEngine.UIElements;

public class Entity_StatusEffect : MonoBehaviour
{
    private Entity entity;

    private void Awake()
    {
        entity = GetComponent<Entity>();
    }

    public void ApplyElementalVfx(ElementalType elementalType)
    {
        if (elementalType == ElementalType.IceElement)
            ChillEffectVfx(3);
    }
    
    public void ChillEffectVfx(float duration)
    {
        entity.SlowdownEffect(duration);
    }
}
