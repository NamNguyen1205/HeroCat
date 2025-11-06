using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_EquippedSlot : MonoBehaviour
{
    public ItemType equipType;
    private Inventory_EquipmentSlot equipSlot;

    [SerializeField] private Image equipIcon;

    public void UpdateEquipSlot(Inventory_EquipmentSlot equip)
    {
        equipSlot = equip;

        if (equipSlot.equipedItem.itemData == null)
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
}
