using UnityEngine;

[CreateAssetMenu(menuName = "RPG Setup/Skill Data", fileName = "Skill data - ")]
public class SkillDataOS : ScriptableObject
{
    [Header("Skill description")]
    public string skillName;
    [TextArea]
    public string skillDescription;
    public Sprite skillIcon;
}
