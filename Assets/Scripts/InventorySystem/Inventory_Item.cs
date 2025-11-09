using System;
using UnityEngine;

[Serializable]
public class Inventory_Item
{
    public string itemId;
    public ItemDataSO itemData;
    public int currentStackSize = 1;

    public ItemModifier[] itemModifiers;

    public Inventory_Item(ItemDataSO itemData)
    {
        this.itemData = itemData;
        itemId = Guid.NewGuid().ToString();


        if (EquipmentData(itemData) != null)
            this.itemModifiers = EquipmentData(itemData).itemModifiers;
    }

    //ep kieu
    public EquipmentDataSO EquipmentData(ItemDataSO itemData)
    {
        if (itemData is EquipmentDataSO equipment)
            return equipment;

        return null;
    }

    public void AddItemModifierToStat(Player_Stat playerStat)
    {
        foreach (var itemModifier in itemModifiers)
        {
            playerStat.GetStatByType(itemModifier.statType).AddModifier(itemModifier.value, itemData.itemName);
        }
    }

    public void RemoveItemModifierFromStat(Player_Stat playerStat)
    {
        foreach (var itemModifier in itemModifiers)
        {
            playerStat.GetStatByType(itemModifier.statType).RemoveModifier(itemData.itemName);
        }
    }

    public void RemoveStack() => currentStackSize--;

}
