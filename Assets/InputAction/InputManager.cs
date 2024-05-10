using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    private PlayerControl playerControl;
    private Camera mainCamera;
    public static InputManager Instance;

    public Action<Vector2, float> OnStartTouch, OnEndTouch;

    private void Awake()
    {
        Instance = this;
        playerControl = new PlayerControl();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        playerControl.Touch.PrimaryContact.started += context => StartTouchPrimary(context);
        playerControl.Touch.PrimaryContact.canceled += context => EndTouchPrimary(context);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCamera,
            playerControl.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCamera,
            playerControl.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera,
            playerControl.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }
}
