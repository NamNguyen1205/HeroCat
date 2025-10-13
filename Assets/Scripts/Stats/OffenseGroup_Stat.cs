using System;
using UnityEngine;

[Serializable]
public class OffenseGroup_Stat
{
    //physical damage
    public Stat physicalDamage;
    public Stat critChance;
    public Stat critDamage;
    public Stat armorReduction;

    //elemental Damage
    public Stat fireDamage;
    public Stat iceDamage;
    public Stat electricDamage;

}
