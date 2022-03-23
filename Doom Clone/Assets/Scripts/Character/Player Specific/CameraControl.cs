using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    #region values
    [SerializeField][Range(0.1f, 1f)] private float mouseSensitivity = 1f;
    [SerializeField][Range(0.1f, 10f)] private float mouseSmoothing = 10f;
    #endregion
    #region references
    private float xMousePosition;
    private float smoothedMousePosition;
    private float currentLookingPosition;
    #endregion

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        GetInput();
        ModifyInput();
        MoveCamera();
    }

    private void GetInput()
    {
        xMousePosition = Input.GetAxisRaw("Mouse X");
    }
    private void ModifyInput()
    {
        xMousePosition *= mouseSensitivity * mouseSmoothing;
        smoothedMousePosition = Mathf.Lerp(smoothedMousePosition, xMousePosition, 1f / mouseSmoothing);
    }
    private void MoveCamera()
    {
        currentLookingPosition += smoothedMousePosition;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPosition, transform.up);
    }
}
