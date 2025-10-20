using Unity.Mathematics;
using UnityEngine;

public class SkillObject_FireBullet : SkillObject_Bullet
{
    [SerializeField] private GameObject fireAoe;
    protected override void OnTriggerEnter2D(Collider2D target)
    {
        base.OnTriggerEnter2D(target);

        //tao ra 1 vung sat thuong lien tuc tai vi tri va cham
        GameObject fireArea = Instantiate(fireAoe, transform.position, Quaternion.identity);

        fireArea.GetComponent<SkillObject_FireEffectAoe>().GetSkillInfor(player, playerStat, scaleDamage);
        
    }
}
