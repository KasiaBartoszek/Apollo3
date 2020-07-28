using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Applies b
/// </summary>
public class BackCameraPositioning : MonoBehaviour
{
    public Camera BackCamera;
    public RawImage BackCameraTarget;
    public float TargetX;
    public float HiddenX;
    public float SlidingSpeed;

    private float currentX;
    private bool IsVisible;

    private void Start()
    {
        currentX = HiddenX;
        UpdateTargetPostion();
    }

    void Update()
    {
        if (BackCamera.enabled)
        {
            if (currentX < TargetX)
            {
                currentX += SlidingSpeed * Time.deltaTime;
                UpdateTargetPostion();
            }
        }
        else
        {
            if (currentX > HiddenX)
            {
                currentX -= 2 * SlidingSpeed * Time.deltaTime;
                UpdateTargetPostion();
            }
        }
    }

    private void UpdateTargetPostion()
    {
        BackCameraTarget.transform.localPosition = new Vector3(currentX, BackCameraTarget.transform.localPosition.y);
    }
}
