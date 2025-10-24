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
    private TextMeshProUGUI itemStack;

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
            return;
        }
        itemIcon.color = Color.white;
        itemIcon.sprite = itemInSlot.itemData.itemIcon;
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
