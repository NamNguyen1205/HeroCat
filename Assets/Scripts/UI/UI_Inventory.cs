using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory_Player inventoryPlayer;
    [SerializeField] private UI_ItemSlotParent itemSlotParent;
    [SerializeField] private UI_EquipSlotParent equipSlotParent;
    [SerializeField] private TextMeshProUGUI gold;

    private void Awake()
    {
        inventoryPlayer = FindFirstObjectByType<Inventory_Player>();

        inventoryPlayer.OnInventoryChanged += UpdateUIInventory;
        inventoryPlayer.onEquipSlotChange += UpdateUIEquipSlot;

        UpdateGold();
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

    private void UpdateGold() => gold.text = inventoryPlayer.gold.ToString();
}
