using System.Collections.Generic;
using UnityEngine;

public class UI_EquipSlotParent : MonoBehaviour
{
    private UI_EquippedSlot[] equipSlots;
    
    public void UpDateUIEquipSlots(List<Inventory_EquipmentSlot> equipList)
    {
        if (equipSlots == null)
            equipSlots = GetComponentsInChildren<UI_EquippedSlot>();

        for (int i = 0; i < equipSlots.Length; i++)
        {
            var equipSlot = equipList[i];

            equipSlots[i].UpdateEquipSlot(equipSlot);
            // if (equipSlot.HasItem() == false)
            //     equipSlots[i].UpdateEquipSlot(equipSlot);
            // else
            //     equipSlots[i].UpdateEquipSlot(equipSlot);
        }
    }
}
