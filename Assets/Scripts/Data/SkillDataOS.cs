using UnityEngine;

[CreateAssetMenu(menuName = "RPG Setup/Skill Data", fileName = "Skill data - ")]
public class SkillDataOS : ScriptableObject
{
    [Header("Skill description")]
    public string skillName;
    [TextArea]
    public string skillDescription;
    public Sprite skillIcon;

    [Header("Skill infor")]
    public float cooldown = 0;
    public float scaleDamage = 1.5f;
    public float duration = 0;
    public float takeDamageTime = 0;
    public bool unlockDefault;
    public bool isUnlocked;
    public SkillType skillType;
    public SkillUpgradeType skillUpgradeType;
}
