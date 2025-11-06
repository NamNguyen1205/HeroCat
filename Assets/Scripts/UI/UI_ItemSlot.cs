using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Inventory_Player inventoryPlayer;
    private Inventory_Item itemInSlot;
    [Header("Slot Info")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemStack;

    private void Awake()
    {
        inventoryPlayer = FindFirstObjectByType<Inventory_Player>();
    }

    public void UpdateSlot(Inventory_Item item)
    {
        itemInSlot = item;

        if (itemInSlot == null)
        {
            itemIcon.color = new Color(1, 1, 1, 0);
            itemStack.text = "";
            return;
        }
        itemIcon.color = Color.white;
        itemIcon.sprite = itemInSlot.itemData.itemIcon;

        if(itemStack != null)
            itemStack.text = itemInSlot.currentStackSize == 1 ? "" : itemInSlot.currentStackSize.ToString();

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        //TryEquipItem(itemInSlot) -> truyen vao itemInSlot
        inventoryPlayer.TryEquipItem(itemInSlot);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
