using System;
using UnityEngine;

[Serializable]
public class LayerBackGround
{
    [SerializeField] private Transform background;
    [SerializeField] private float speedMultiplier;

    private float imageFullWidth;
    private float imageHalfWidth;

    public void CalculateImageWidth()
    {
        imageFullWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalfWidth = imageFullWidth / 2;
    }

    public void Move(float direction)
    {
        background.position += Vector3.right * direction * speedMultiplier;
    }

    public void LoopingBackGround(float cameraLeftEdge, float cameraRigthEdge)
    {
        float imageLeftEdge = background.position.x - imageHalfWidth;
        float imageRightEdge = background.position.x + imageHalfWidth;

        if (cameraLeftEdge > imageRightEdge)
            background.position += Vector3.right * imageFullWidth;
        if (cameraRigthEdge < imageLeftEdge)
            background.position -= Vector3.right * imageFullWidth;
    }


}
