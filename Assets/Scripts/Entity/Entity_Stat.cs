using UnityEditor.Rendering;
using UnityEngine;

public class Entity_Stat : MonoBehaviour
{
    public MajorGroup_Stat majorGroup;
    public OffenseGroup_Stat offenseGroup;
    public DefenseGroup_Stat defenseGroup;

    public float GetMaxHealth()
    {
        float baseHealth = majorGroup.maxHealth.GetValue();
        float bonusHealth = majorGroup.vitality.GetValue() * 5;

        float finalMaxHealth = baseHealth + bonusHealth;
        return finalMaxHealth;
    }

    public float GetPhysicalDamage()
    {
        float baseDamage = offenseGroup.physicalDamage.GetValue();
        float bonusDamage = majorGroup.strength.GetValue();

        float totalDamage = baseDamage + bonusDamage;

        float finalDamage = HitCrit() ? totalDamage * (offenseGroup.critDamage.GetValue() / 100f) : totalDamage;
            

        return finalDamage;
    }

    private bool HitCrit() => Random.Range(0, 100) < offenseGroup.critChance.GetValue(); //critchance = 37 => 37%
}
