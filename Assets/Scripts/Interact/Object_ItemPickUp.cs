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
        if(collision.CompareTag("Player"))
        {
            Debug.Log("pick up");
        }
    }

    private void OnValidate()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = itemData.itemIcon;
        gameObject.name = "Object_Item - " + itemData.itemName;
    }
}
