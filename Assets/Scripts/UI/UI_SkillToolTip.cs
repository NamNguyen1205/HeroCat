using TMPro;
using UnityEngine;

public class UI_SkillToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillDescription;
    private RectTransform toolTipRect;
    [Header("Update Tool tip")]
    public float offsetX;
    public float offsetY;

    private void Awake()
    {
        toolTipRect = GetComponent<RectTransform>();
;    }

    public void UpdateSkillInfo(string name, string description)
    {
        skillName.text = name;
        skillDescription.text = description;
    }
}
