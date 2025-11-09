using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_EquippedSlot : MonoBehaviour, IPointerDownHandler
{
    private Inventory_Player inventoryPlayer;

    public ItemType equipType;
    private Inventory_EquipmentSlot equipSlot;

    [SerializeField] private Image equipIcon;

    private void Awake()
    {
        inventoryPlayer = FindFirstObjectByType<Inventory_Player>();
    }

    public void UpdateEquipSlot(Inventory_EquipmentSlot equip)
    {
        equipSlot = equip;

        if (equipSlot.equipedItem == null || equipSlot.equipedItem.itemData == null )
        {
            equipIcon.color = new Color(1, 1, 1, 0);
            return;
        }

        equipIcon.color = Color.white;
        equipIcon.sprite = equip.equipedItem.itemData.itemIcon;
    }

    private void OnValidate()
    {
        gameObject.name = $"equipSlot - {equipType}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (equipSlot.equipedItem == null) return;

        inventoryPlayer.UnEquipItem(equipSlot.equipedItem);
    }
}
