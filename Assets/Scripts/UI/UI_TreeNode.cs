using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_TreeNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private string skillName;
    private string skillDescription;
    private Sprite skillIcon;
    [SerializeField] private SkillDataOS skillData;
    [SerializeField] private Image iconImage;

    [SerializeField] private UI_SkillToolTip skillToolTip;
    private RectTransform treeNodeRect;
    private RectTransform toolTipRect;
    private Player_SkillManager skillManager;
    [Header("Needed Skill")]
    [SerializeField] private UI_TreeNode[] neededSkillNodes;
    [SerializeField] private UI_TreeNode[] conflictSkillNodes;
    [SerializeField] private bool isUnlocked = false;

    private void Awake()
    {
        InitializeSkill();
        treeNodeRect = GetComponent<RectTransform>();
        toolTipRect = skillToolTip.GetComponent<RectTransform>();
        skillManager = FindFirstObjectByType<Player_SkillManager>();
        isUnlocked = skillData.isUnlocked;
    }

    private void InitializeSkill()
    {
        this.skillName = skillData.skillName;
        this.skillDescription = skillData.skillDescription;
        this.skillIcon = skillData.skillIcon;
    }

    private void Start()
    {
        //check skill unlock default or not and render it
        if(skillData.unlockDefault == false)
            SkillLockedVisual();
    }

    private void SkillLockedVisual()
    {
        Color color = Color.gray;
        color.a = 0.5f;
        iconImage.color = color;
    }
    
    private void SkillUnlockedVisual()
    {
        Color color = Color.white;
        color.a = 1;
        iconImage.color = color;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //unlock skill
        UnlockSkill();
    }

    private void UnlockSkill()
    {
        //check skill is unlocked or not
        if (isUnlocked == true)
            return;
        //check skill needed is unlocked or not
        if (NeededSkillIsUnlocked() == false)
            return;
        // check skill conflict is unlocked or not
        if (ConflictSkillIsLocked() == false)
            return;

        //unlock skill
        skillManager.GetSkillUnlockByType(skillData.skillType).SetUnlockByUpgradeType(skillData);
        isUnlocked = true;
        SkillUnlockedVisual();

    }

    private bool NeededSkillIsUnlocked()
    {
        foreach (var neededSkill in neededSkillNodes)
        {
            if (neededSkill.isUnlocked == false)
                return false;
        }

        return true;
    }
    //all skill conflict need be locked
    private bool ConflictSkillIsLocked()
    {
        foreach (var conflictSkill in conflictSkillNodes)
        {
            if (conflictSkill.isUnlocked == true)
                return false;
        }

        return true;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        skillToolTip.UpdateSkillInfo(skillName, skillDescription);
        skillToolTip.ShowToolTip(true, treeNodeRect);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        skillToolTip.ShowToolTip(false, treeNodeRect);
    }

    private void OnValidate()
    {
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        gameObject.name = "Skill Node - " + skillData.skillName;
        iconImage.sprite = skillData.skillIcon;
    }

}
