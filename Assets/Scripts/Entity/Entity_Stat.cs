using System.Net.Http.Headers;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Entity_Stat : MonoBehaviour
{
    public MajorGroup_Stat majorGroup;
    public OffenseGroup_Stat offenseGroup;
    public DefenseGroup_Stat defenseGroup;

    public virtual float GetMaxHealth()
    {
        float baseHealth = majorGroup.maxHealth.GetValue();
        float bonusHealth = majorGroup.vitality.GetValue() * 5;

        float finalMaxHealth = baseHealth + bonusHealth;
        return finalMaxHealth;
    }

    public virtual float GetPhysicalDamage(float scaleDamage = 1)
    {
        float baseDamage = offenseGroup.physicalDamage.GetValue();
        float bonusDamage = majorGroup.strength.GetValue();

        float totalDamage = (baseDamage + bonusDamage) * scaleDamage;

        float finalDamage = HitCrit() ? totalDamage * (offenseGroup.critDamage.GetValue() / 100f) : totalDamage;


        return finalDamage;
    }

    public virtual float GetElementalDamage(ElementalType elementalType, float scaleDamage = 1)
    {
        float finalDamage = 0;
        return finalDamage;
    }



    protected virtual bool HitCrit() => Random.Range(0, 100) < offenseGroup.critChance.GetValue(); //critchance = 37 => 37%
    
    public Stat GetStatByType(StatType statType)
    {
        switch (statType)
        {
            case StatType.maxHealth: return majorGroup.maxHealth;
            case StatType.strength: return majorGroup.strength;
            case StatType.agility: return majorGroup.agility;
            case StatType.intelligence: return majorGroup.intelligence;
            case StatType.vitality: return majorGroup.vitality;

            case StatType.physicalDamage: return offenseGroup.physicalDamage;
            case StatType.critChance: return offenseGroup.critChance;
            case StatType.critDamage: return offenseGroup.critDamage;
            case StatType.armorReduction: return offenseGroup.armorReduction;
            case StatType.fireDamage: return offenseGroup.fireDamage;
            case StatType.iceDamage: return offenseGroup.iceDamage;
            case StatType.electricDamage: return offenseGroup.electricDamage;

            case StatType.armor: return defenseGroup.armor;
            case StatType.resistance: return defenseGroup.resistance;
            case StatType.resistEffect: return defenseGroup.resistEffect;

            default: return null;
        }
    }
}
