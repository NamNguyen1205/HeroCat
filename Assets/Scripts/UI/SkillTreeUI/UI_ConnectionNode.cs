using System;
using UnityEngine;

[Serializable]
public class ConnectionLineDetail
{
    public RectTransform connectionLine;
    [Range(100, 300)]
    public float length;
    public LineDirection lineDirection;
    public RectTransform connectPoint;
    public RectTransform childNode;
    
}

public class UI_ConnectionNode : MonoBehaviour
{
    [SerializeField] private ConnectionLineDetail[] connectionLines;

    private void OnValidate()
    {
        UpdateLine();
    }

    [ContextMenu("UpdatePosition")]
    private void UpdateLine()
    {
        foreach (var line in connectionLines)
        {
            if (line.childNode == null)
                continue;

            UpdateLength(line);
            UpdateDirectionAngle(line);
        }
    }

    private void UpdateLength(ConnectionLineDetail line) => line.connectionLine.sizeDelta = new Vector2(line.length, line.connectionLine.sizeDelta.y);
    
    private void UpdateDirectionAngle(ConnectionLineDetail line)
    {
        float directionAngle = GetDirectionAngle(line.lineDirection);

        line.connectionLine.eulerAngles = new Vector3(0, 0, directionAngle);
        UpdateChildNodePosition(line);
    }

    private void UpdateChildNodePosition(ConnectionLineDetail line)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (
            line.childNode.parent as RectTransform,
            line.connectPoint.position,
            null,
            out var localPosition
        );
        line.childNode.anchoredPosition = localPosition;
    }
    
    private float GetDirectionAngle(LineDirection direction)
    {
        switch(direction)
        {
            case LineDirection.upLeft: return 135;
            case LineDirection.up: return 90;
            case LineDirection.upRight: return 45;
            case LineDirection.left: return 180;
            case LineDirection.right: return 0;
            case LineDirection.downLeft: return 225;
            case LineDirection.down: return 270;
            case LineDirection.downRight: return 315;
            default: return 0;
        }
    }
}

public enum LineDirection
{
    upLeft,
    up,
    upRight,
    left,
    right,
    downLeft,
    down,
    downRight,
}