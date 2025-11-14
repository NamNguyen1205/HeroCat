using UnityEngine;

public class Player_SkillManager : MonoBehaviour
{
    [SerializeField] private int skillPoint = 5;
    public Skill_NaCaoSu skill_NaCaoSu;
    public Skill_Dash skill_Dash;

    private void Awake()
    {
        skill_NaCaoSu = GetComponentInChildren<Skill_NaCaoSu>();
        skill_Dash = GetComponentInChildren<Skill_Dash>();
    }

    //unlock skill by get SkillType from UI_TreeNode
    public Skill_Base GetSkillUnlockByType(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.NaCaoSu:
                return skill_NaCaoSu;
            case SkillType.Dash:
                return skill_Dash;

            default:
                return null;
        }
    }

    public int SetSkillPoint(int skillPoint) => this.skillPoint = skillPoint;
    public int GetSkillPoint() => skillPoint;
}
