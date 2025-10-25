using UnityEngine;

public class Object_ItemPickUp : MonoBehaviour
{
    public ItemDataSO itemData;
    public SpriteRenderer sr;

    private void Awake()
    {

    }
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        Inventory_Item itemToAdd = new Inventory_Item(itemData);
        Inventory_Player playerInventory = collision.gameObject.GetComponent<Inventory_Player>();

        if(playerInventory.CanAddItem() == false)
            return;

        playerInventory.AddItem(itemToAdd);
        
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = itemData.itemIcon;
        gameObject.name = "Object_Item - " + itemData.itemName;
    }
}
