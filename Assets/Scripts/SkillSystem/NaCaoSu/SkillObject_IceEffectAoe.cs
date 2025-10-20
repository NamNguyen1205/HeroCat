using UnityEngine;

public class SkillObject_IceEffectAoe : SkillObject_EffectAoe
{
    protected override void ApplyEffectInArea()
    {
        elementalType = ElementalType.IceElement;
        base.ApplyEffectInArea();

    }
}
