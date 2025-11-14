using UnityEngine;

public class Skill_Base : MonoBehaviour
{
    protected bool isUnlocked;
    public SkillUpgradeType skillUpgradeType;
    private float lastTimeUsed;
    [SerializeField] protected float cooldown;
    [SerializeField] protected float scaleDamage;

    protected virtual void Awake()
    {
        lastTimeUsed = lastTimeUsed - cooldown;
    }

    //skill cooldown
    protected void StartCooldown() => lastTimeUsed = Time.time;
    public bool OnCooldown() => Time.time < lastTimeUsed + cooldown;

    //Set skill Upgrade type and change skill upgrade infor
    public void SetUnlockByUpgradeType(SkillDataSO skillData)
    {
        skillUpgradeType = skillData.skillUpgradeType;
        cooldown = skillData.cooldown;
        scaleDamage = skillData.scaleDamage;
    }

    public float GetCoolDown() => cooldown;
    
}
