using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item Data/Item Effect/Heal effect", fileName = "Item effect data - Heal")]
public class ItemEffect_Heal : ItemEffectDataSO
{
    [SerializeField] private float healValue;
    public override void ExecuteEffect()
    {
        Entity_Health playerHealth = FindFirstObjectByType<Player_Entity>().gameObject.GetComponent<Entity_Health>();

        playerHealth.HealHP(healValue);
    }
}
