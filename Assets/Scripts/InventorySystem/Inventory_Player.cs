using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Player : Inventory_Base
{
    public event Action onEquipSlotChange;
    public List<Inventory_EquipmentSlot> equipList;

    public void TryEquipItem(Inventory_Item itemToEquip)
    {
        var matchingSlots = equipList.FindAll(slot => slot.equipType == itemToEquip.itemData.itemType);

        if (matchingSlots == null) return;

        foreach (var slot in matchingSlots)
        {
            if (slot.HasItem() == false)
                EquipItem(itemToEquip, slot);
        }

    }

    private void EquipItem(Inventory_Item itemToEquip, Inventory_EquipmentSlot equipSlot)
    {
        //add item to EquipList
        equipSlot.equipedItem = itemToEquip;
        //update equipSlotUI
        onEquipSlotChange?.Invoke();
        //remove equip in bag
        RemoveItem(itemToEquip);
        //add item Modifier in player stat
    }
    
}
