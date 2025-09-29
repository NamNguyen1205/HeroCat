using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Inventory/Item", order = 1)]
public class item : ScriptableObject
{
    public GameObject prefab;
    public string itemName;
    public Sprite icon;
    public int id;
}
