using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputDirector : MonoBehaviour
{
    public event Action MoveForwardEvent;
    public event Action MoveBackwardEvent;
    public event Action MoveLeftEvent;
    public event Action MoveRightEvent;

    public event Action RotateLeftEvent;
    public event Action RotateRightEvent;

    private Action MovementActions, RotateActions;
    [SerializeField] private InputData inputData;
    [SerializeField] private DataContainer dataContainer;
    [SerializeField] private GameSetup gameSetup;
    [SerializeField] private GameOver gameOver;

    private void Start()
    {
        gameSetup.EnableInputEvent += GameSetup_DelayedEnableInput;

        gameOver.DisableInputEvent += GameOver_DisableInput;
    }
    private void Update()
    {
            if (MovementActions != null) MovementActions();
            if (RotateActions != null) RotateActions();
    }

    private void OnMoveForward()
    {
        if (Input.GetKey(inputData.moveForward))
        {
            MoveForwardEvent?.Invoke();
        }
    }
    private void OnMoveBackward()
    {
        if (Input.GetKey(inputData.moveBackward))
        {
            MoveBackwardEvent?.Invoke();
        }
    }
    private void OnMoveLeft()
    {
        if (Input.GetKey(inputData.moveLeft))
        {
            MoveLeftEvent?.Invoke();
        }
    }
    private void OnMoveRight()
    {
        if (Input.GetKey(inputData.moveRight))
        {
            MoveRightEvent?.Invoke();
        }
    }
    private void OnRotationLeft()
    {
        if (Input.GetKey(inputData.rotateLeft))
        {
            RotateLeftEvent?.Invoke();
        }
    }
    private void OnRotationRight()
    {
        if (Input.GetKey(inputData.rotateRight))
        {
            RotateRightEvent?.Invoke();
        }
    }

    private void GameSetup_DelayedEnableInput()
    {
        Invoke("EnableInput", 0.05f);
    }

    private void EnableInput()
    {
        MovementActions += OnMoveForward;
        MovementActions += OnMoveBackward;
        MovementActions += OnMoveLeft;
        MovementActions += OnMoveRight;
        RotateActions += OnRotationLeft;
        RotateActions += OnRotationRight;
    }

    private void GameOver_DisableInput()
    {
        MovementActions -= OnMoveForward;
        MovementActions -= OnMoveBackward;
        MovementActions -= OnMoveLeft;
        MovementActions -= OnMoveRight;
        RotateActions -= OnRotationLeft;
        RotateActions -= OnRotationRight;
    }
}
