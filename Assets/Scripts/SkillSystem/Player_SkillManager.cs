using UnityEngine;

public class Player_SkillManager : MonoBehaviour
{
    public Skill_NaCaoSu skill_NaCaoSu;

    private void Awake()
    {
        skill_NaCaoSu = GetComponentInChildren<Skill_NaCaoSu>();
    }

    //unlock skill by get SkillType from UI_TreeNode
    public Skill_Base GetSkillUnlockByType(SkillType skillType)
    {
        switch(skillType)
        {
            case SkillType.NaCaoSu:
                return skill_NaCaoSu;

            default:
                return null;
        }
    }
}
