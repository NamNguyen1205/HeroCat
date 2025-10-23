using TMPro;
using UnityEngine;

public class UI_SkillToolTip : UI_ToolTip
{
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillDescription;
    public void UpdateSkillInfo(string name, string description)
    {
        skillName.text = name;
        skillDescription.text = description;
    }
}
