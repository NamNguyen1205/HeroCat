using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

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

    public float GetPhysicalDamage(float scaleDamage = 1)
    {
        float baseDamage = offenseGroup.physicalDamage.GetValue();
        float bonusDamage = majorGroup.strength.GetValue();

        float totalDamage = (baseDamage + bonusDamage) * scaleDamage;

        float finalDamage = HitCrit() ? totalDamage * (offenseGroup.critDamage.GetValue() / 100f) : totalDamage;


        return finalDamage;
    }

    public float GetElementalDamage(ElementalType elementalType, float scaleDamage = 1)
    {
        float finalDamage = 0;
        return finalDamage;
    }

    

    private bool HitCrit() => Random.Range(0, 100) < offenseGroup.critChance.GetValue(); //critchance = 37 => 37%
}
