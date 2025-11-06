using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Equipment", fileName = "Equipment data - ")]
public class EquipmentDataSO : ItemDataSO
{

    [Header("Item Modifier")]
    public ItemModifier[] itemModifiers;
}

[Serializable]
public class ItemModifier
{
    public StatType statType;
    public float value;
}