using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; set; }

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private CharacterController charController;
    [SerializeField] private InputDirector inputDirector;
    private Vector3 moveDirection;
    private void Start()
    {
        instance = this;
        inputDirector.MoveForwardEvent += InputDirector_MoveForward;
        inputDirector.MoveBackwardEvent += InputDirector_MoveBackward;
        inputDirector.MoveLeftEvent += InputDirector_MoveLeft;
        inputDirector.MoveRightEvent += InputDirector_MoveRight;
        inputDirector.RotateLeftEvent += InputDirector_RotateLeft;
        inputDirector.RotateRightEvent += InputDirector_RotateRight;
    }
    private void InputDirector_MoveForward()
    {
        moveDirection = (transform.forward);
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void InputDirector_MoveBackward()
    {
        moveDirection = (-transform.forward);
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void InputDirector_MoveLeft()
    {
        moveDirection = (-transform.right);
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void InputDirector_MoveRight()
    {
        moveDirection = (transform.right);
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void InputDirector_RotateLeft()
    {
        transform.Rotate(-transform.up * Time.deltaTime * rotateSpeed);
    }
    private void InputDirector_RotateRight()
    {
        transform.Rotate(transform.up * Time.deltaTime * rotateSpeed);
    }
}
