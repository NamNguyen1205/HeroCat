using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Base : MonoBehaviour
{
    public event Action OnInventoryChanged;

    private int inventoryMaxSize = 10;
    public List<Inventory_Item> itemList;

    protected virtual void Awake()
    {
        itemList = new List<Inventory_Item>();
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
