using UnityEngine;

public class SkillObject_IceBullet : SkillObject_Bullet
{
    [SerializeField] private GameObject iceAoe;
    protected override void OnTriggerEnter2D(Collider2D target)
    {
        base.OnTriggerEnter2D(target);

        //tao ra 1 vung sat thuong lien tuc tai vi tri va cham
        GameObject fireArea = Instantiate(iceAoe, transform.position, Quaternion.identity);

        fireArea.GetComponent<SkillObject_IceEffectAoe>().GetSkillInfor(player, playerStat, scaleDamage);
        
    }
}
