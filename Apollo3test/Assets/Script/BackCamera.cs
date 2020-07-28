using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/// <summary>
/// Responsible for updating the back camera.
/// </summary>
public class BackCamera : MonoBehaviour
{
    public Camera BackCameraInstance;
    public KeyCode EnableButton;

    private void Start()
    {
        BackCameraInstance.enabled = false;
    }

    void Update()
    {
        var input = Input.GetKey(EnableButton);

        BackCameraInstance.enabled = input;

        if (input == true)
        {
            var mainCameraTransform = Camera.main.transform;
            BackCameraInstance.transform.forward = -mainCameraTransform.forward;
        }
    }
}
