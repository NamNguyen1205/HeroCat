using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] private float baseValue = 0;
    public float GetValue()
    {
        return baseValue;
    }
}
