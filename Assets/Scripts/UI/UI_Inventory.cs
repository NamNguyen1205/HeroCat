using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory_Player inventoryPlayer;
    [SerializeField] private UI_ItemSlotParent itemSlotParent;

    private void Awake()
    {
        inventoryPlayer = FindFirstObjectByType<Inventory_Player>();
        
        inventoryPlayer.OnInventoryChanged += UpdateUIInventory;
        UpdateUIInventory();
    }

    public void UpdateUIInventory()
    {
        // Update the UI with the player's inventory items
        itemSlotParent.UpDateUISlots(inventoryPlayer.itemList);
    }
}
