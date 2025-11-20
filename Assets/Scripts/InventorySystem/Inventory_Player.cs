using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory_Player : Inventory_Base
{
    public float gold;
    public event Action onEquipSlotChange;
    public List<Inventory_EquipmentSlot> equipList;

    public void TryEquipItem(Inventory_Item itemToEquip)
    {
        var matchingSlots = equipList.FindAll(slot => slot.equipType == itemToEquip.itemData.itemType);

        if (matchingSlots == null) return;

        foreach (var slot in matchingSlots)
        {

            if (slot.HasItem())
                continue;

            EquipItem(itemToEquip, slot);
            return;
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
        itemToEquip.AddItemModifierToStat(playerStat);
        
        entityHealth.UpdateCurrentHealth();
    }

    public void UnEquipItem(Inventory_Item itemToUnequip)
    {
        if (itemToUnequip.itemData == null) return;

        var matchingSlots = equipList.FindAll(slot => slot.equipType == itemToUnequip.itemData.itemType);

        foreach (var slot in matchingSlots)
        {
            if (slot.equipedItem.itemId == itemToUnequip.itemId)
            {
                slot.equipedItem = null;
                AddItem(itemToUnequip);
                break;

            }
        }

        //update ui
        onEquipSlotChange?.Invoke();
        //remove item modifiers
        itemToUnequip.RemoveItemModifierFromStat(playerStat);
        entityHealth.UpdateCurrentHealth();
    }

    public override void SaveData(ref GameData gameData)
    {
        gameData.gold = this.gold;
        gameData.itemList = this.itemList;
    }

    public override void LoadData(GameData gameData)
    {
        this.gold = gameData.gold;
        this.itemList = gameData.itemList;
    }
}
