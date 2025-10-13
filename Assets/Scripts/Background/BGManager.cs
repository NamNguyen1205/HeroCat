using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    private Camera mainCamera;
    private float lastCameraPosititon = 0;
    private float cameraHalfWidth;
    [SerializeField] private LayerBackGround[] backGroungLayers;

    private void Awake()
    {
        mainCamera = Camera.main;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        Initialize();
    }

    private void FixedUpdate()
    {
        float currentCamPositionX = mainCamera.transform.position.x;
        float backgroundDirection = currentCamPositionX - lastCameraPosititon;
        lastCameraPosititon = currentCamPositionX;

        float cameraLeftEdge = currentCamPositionX - cameraHalfWidth;
        float cameraRigthEdge = currentCamPositionX + cameraHalfWidth;

        foreach (var background in backGroungLayers)
        {
            background.Move(backgroundDirection);
            background.LoopingBackGround(cameraLeftEdge, cameraRigthEdge);
        }
    }
    
    private void Initialize()
    {
        foreach (var background in backGroungLayers)
        {
            background.CalculateImageWidth();
        }
    }
}
