using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item Data", fileName = "Item data - ")]
public class ItemDataSO : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;
    public int maxStackSize = 1;

    public ItemEffectDataSO itemEffectData;
    
}
