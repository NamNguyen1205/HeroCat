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

    private void Awake()
    {
        InitializeSkill();
        treeNodeRect = GetComponent<RectTransform>();
        toolTipRect = skillToolTip.GetComponent<RectTransform>();
    }

    private void InitializeSkill()
    {
        this.skillName = skillData.skillName;
        this.skillDescription = skillData.skillDescription;
        this.skillIcon = skillData.skillIcon;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //unlock skill
        UnlockSkill();
    }

    private void UnlockSkill()
    {
        
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
