using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Accessibility;

public class Inventory_Base : MonoBehaviour
{
    private int inventoryMaxSize = 10;
    public List<Inventory_Item> itemList;

    protected virtual void Awake()
    {
        itemList = new List<Inventory_Item>();
    }

    protected virtual void AddItem(Inventory_Item itemToAdd)
    {

        itemList.Add(itemToAdd);
    }

    protected virtual void RemoveItem(Inventory_Item itemToRemove)
    {


        itemList.Remove(itemToRemove);
    }
}
