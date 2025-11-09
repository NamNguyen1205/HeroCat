using System;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class Stat
{
    [SerializeField] private float baseValue = 0;
    [SerializeField] private List<StatModifier> statModifiers = new List<StatModifier>();
    [SerializeField] private float finalValue;
    public float GetValue()
    {
        finalValue = baseValue;

        finalValue = GetFinalValue();

        return finalValue;
    }

    //them chỉ số khi được buff, trang bị, skill
    public void AddModifier(float value, string source)
    {
        StatModifier modToAdd = new StatModifier(value, source);
        statModifiers.Add(modToAdd);
    }

    public void RemoveModifier(string source)
    {
        statModifiers.RemoveAll(stat => stat.source == source);
    }

    public float GetFinalValue()
    {
        float totalValue = baseValue;
        foreach (var modifier in statModifiers)
        {
            totalValue += modifier.value;
        }
        return totalValue;
    }
}

[Serializable]
public class StatModifier
{
    public float value;
    public string source;

    public StatModifier(float value, string source)
    {
        this.value = value;
        this.source = source;
    }
}
