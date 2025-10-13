using UnityEngine;
using UnityEngine.EventSystems;

public class UI_TreeNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private string skillName;
    private string skillDescription;
    private Sprite skillIcon;
    [SerializeField] private SkillDataOS skillData;

    [SerializeField] private UI_SkillToolTip skillToolTip;

    private void Awake()
    {
        InitializeSkill();

    }

    private void InitializeSkill()
    {
        this.skillName = skillData.skillName;
        this.skillDescription = skillData.skillDescription;
        this.skillIcon = skillData.skillIcon;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        skillToolTip.UpdateSkillInfo(skillName, skillDescription);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
    }
}
