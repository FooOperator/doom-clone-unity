using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour

{
    #region components
    private CharacterController characterController;
    [SerializeField] private Animator cameraAnimator;
    #endregion
    #region values
    [SerializeField] private float moveVelocity = 10f;
    [SerializeField] private float runBoost = 5f;
    [SerializeField] private float runVelocity;
    private float momentumDamping = 5f;
    private float gravity = -10f;
    #endregion
    #region references
    private Vector3 inputVector;
    private Vector3 movementVector;
    #endregion
    #region bools
    private bool isMoving;
    private bool isRunning;
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        runVelocity = moveVelocity + runBoost;
    }
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckIsMoving();
    }

    private void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        //   inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

        if (isRunning)
        {
            movementVector = (inputVector * runVelocity) + (Vector3.up * gravity);
        }
        else
        {
            movementVector = (inputVector * moveVelocity) + (Vector3.up * gravity);
        }
    }
    private void MovePlayer()
    {
        characterController.Move(movementVector * Time.deltaTime);
    }

    private void CheckIsMoving()
    {
        isMoving = characterController.velocity.magnitude > 0.1f;
        CheckIsRunning();
        cameraAnimator.SetBool("isMoving", isMoving);
    }
    private void CheckIsRunning()
    {
        isRunning = Input.GetButton("Run");
    }
}
