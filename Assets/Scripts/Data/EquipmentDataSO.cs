using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Equipment", fileName = "Item data - ")]
public class EquipmentDataSO : ItemDataSO
{

}

public class ItemModifier
{
    public StatType statType;
    public float value;
}