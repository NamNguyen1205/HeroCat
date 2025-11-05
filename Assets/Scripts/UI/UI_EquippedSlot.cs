using UnityEngine;

public class UI_EquippedSlot : UI_ItemSlot
{
    public ItemType equipType;

    public bool HasEquipInSlot()
    {
        if (itemInSlot == null)
            return false;

        return true;
    }


}
