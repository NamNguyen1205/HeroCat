using UnityEngine;
using TMPro;

public class UI_ToolTip : MonoBehaviour
{
    protected RectTransform toolTipRect;
    [Header("Update Tool tip")]
    public float offsetX;
    public float offsetY;

    protected virtual void Awake()
    {
        toolTipRect = GetComponent<RectTransform>();
    }

    public virtual void ShowToolTip(bool showToolTip, RectTransform targetRect)
    {
        if (showToolTip == false)
            toolTipRect.position = new Vector3(9999, 9999);
        if (showToolTip == true)
            UpdatePosition(targetRect);
    }
    
    protected virtual void UpdatePosition(RectTransform targetRect)
    {
        float screenCenterX = Screen.width / 2;
        float screenBottom = 0;
        float screenTop = Screen.height;

        Vector2 targetPosition = targetRect.position;

        //lay gia tri x
        targetPosition.x = targetRect.position.x > screenCenterX ? targetRect.position.x - offsetX : targetRect.position.x + offsetX;

        float toolTipHalfHeight = toolTipRect.rect.height / 2f;
        float toolTipTop = targetPosition.y + toolTipHalfHeight;
        float toolTipBottom = targetPosition.y - toolTipHalfHeight;

        //lay gia tri y
        if (toolTipTop > screenTop)
            targetPosition.y = screenTop - toolTipHalfHeight - offsetY;
        if (toolTipBottom < screenBottom)
            targetPosition.y = screenBottom + toolTipHalfHeight + offsetY;

        toolTipRect.position = targetPosition;
    }
}
