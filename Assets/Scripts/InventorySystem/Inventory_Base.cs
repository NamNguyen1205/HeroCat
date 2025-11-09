using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory_Base : MonoBehaviour
{
    public event Action OnInventoryChanged;
    protected Player_Stat playerStat;
    protected Entity_Health entityHealth;

    private int inventoryMaxSize = 10;
    public List<Inventory_Item> itemList;

    protected virtual void Awake()
    {
        itemList = new List<Inventory_Item>();
        playerStat = FindFirstObjectByType<Player_Stat>();
        entityHealth = playerStat.gameObject.GetComponent<Entity_Health>();
    }

    public void TryUseItem(Inventory_Item itemToUse)
    {
        if (itemToUse == null) return;

        itemToUse.itemData?.itemEffectData.ExecuteEffect();
    }

    public bool CanAddItem()
    {
        if (itemList.Count < inventoryMaxSize)
            return true;
        else
            return false;
    }

    public bool CanAddStack(Inventory_Item itemToAdd)
    {
        foreach (Inventory_Item item in itemList)
        {
            if (item.itemData == itemToAdd.itemData && item.currentStackSize < item.itemData.maxStackSize)
                return true;
        }

        return false;
    }
    
    public virtual void AddItemStack(Inventory_Item itemToAdd)
    {        
        foreach (Inventory_Item item in itemList)
        {
            if(item.itemData == itemToAdd.itemData && CanAddStack(item))
            {
                item.currentStackSize++;
            }
        }
        OnInventoryChanged?.Invoke();
        
    }

    public virtual void AddItem(Inventory_Item itemToAdd)
    {
        itemList.Add(itemToAdd);

        OnInventoryChanged?.Invoke();
    }

    public virtual void RemoveItem(Inventory_Item itemToRemove)
    {

        itemList.Remove(itemToRemove);

        OnInventoryChanged?.Invoke();
    }
}
