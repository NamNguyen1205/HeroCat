using System;
using UnityEngine;

[Serializable]
public class Inventory_Item
{
    public ItemDataSO itemData;
    public int currentStackSize = 1;


    public Inventory_Item(ItemDataSO itemData)
    {
        this.itemData = itemData; 
    }
}
