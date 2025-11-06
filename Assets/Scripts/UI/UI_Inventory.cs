using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory_Player inventoryPlayer;
    [SerializeField] private UI_ItemSlotParent itemSlotParent;
    [SerializeField] private UI_EquipSlotParent equipSlotParent;

    private void Awake()
    {
        inventoryPlayer = FindFirstObjectByType<Inventory_Player>();

        inventoryPlayer.OnInventoryChanged += UpdateUIInventory;
        inventoryPlayer.onEquipSlotChange += UpdateUIEquipSlot;

        UpdateUIInventory();
        UpdateUIEquipSlot();
    }

    public void UpdateUIInventory()
    {
        // Update the UI with the player's inventory items
        itemSlotParent.UpDateUISlots(inventoryPlayer.itemList);
    }

    public void UpdateUIEquipSlot()
    {
        equipSlotParent.UpDateUIEquipSlots(inventoryPlayer.equipList);
    }
}
