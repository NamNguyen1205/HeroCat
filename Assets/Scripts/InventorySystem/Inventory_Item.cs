using System;
using UnityEngine;

[Serializable]
public class Inventory_Item
{
    public ItemDataSO itemData;
    public int currentStackSize = 1;

    // public ItemModifier 

    //ep kieu
    public EquipmentDataSO EquipmentData(ItemDataSO itemData)
    {
        if (itemData is EquipmentDataSO equipment)
            return equipment;

        return null;
    }

    public void AddItemModifier(Player_Stat playerStat)
    {
        // var modifierList = 
    }

    public Inventory_Item(ItemDataSO itemData)
    {
        this.itemData = itemData;
    }
}
