using UnityEngine;

public class UI_SkillTree : MonoBehaviour
{
    public UI_TreeNode[] allTreeNodes {get; private set; }

    private void Awake()
    {
        // allTreeNodes = GetComponentsInChildren<UI_TreeNode>(true);
    }

    public void InitSkillTree()
    {
        allTreeNodes = GetComponentsInChildren<UI_TreeNode>(true);

        foreach(var treeNode in allTreeNodes)
        {
            treeNode.UnlockDefaultSkill();
        }
    }
}
