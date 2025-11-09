using System;
using UnityEngine;

[Serializable]
public class Inventory_EquipmentSlot
{
    public ItemType equipType;
    public Inventory_Item equipedItem;

    public bool HasItem() => equipedItem != null && equipedItem.itemData != null;

}
