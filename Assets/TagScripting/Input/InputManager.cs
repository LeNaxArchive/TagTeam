using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // There should be only one inputmanager in the game
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    // action schemes
    private RunnerInputAction actionScheme;

    // configuration
    [SerializeField] private float sqrSwipeDeadzone = 50.0f;

    #region public properties
    public bool Tap { get { return tap; } }
    public Vector2 TouchPosition { get { return touchPosition; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    #endregion

    #region privates
    private bool tap;
    private Vector2 touchPosition;
    private Vector2 startDrag;
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeUp;
    private bool swipeDown;
    #endregion

    private void Awake() 
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        SetupControl();

    }
    private void LateUpdate()
    {
        ResetInputs();
    }

    private void ResetInputs()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
    }

    private void SetupControl()
    {
        actionScheme = new RunnerInputAction();

        // REGISTER DIFFRENT ACTIONs
        actionScheme.Gameplay.Tap.performed += ctx => OnTap(ctx);
        actionScheme.Gameplay.TouchPosition.performed += ctx => OnPosition(ctx);
        actionScheme.Gameplay.StartDrag.performed += ctx => OnSartDrag(ctx);
        actionScheme.Gameplay.EndDrag.performed += ctx => OnEndDrag(ctx);
    }

    private void OnEndDrag(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Vector2 delta = touchPosition - startDrag;
        float sqrDistance = delta.sqrMagnitude;

        //confirmed swipe
        if(sqrDistance > sqrSwipeDeadzone)
        {
            float x = Math.Abs(delta.x);
            float y = Math.Abs(delta.y);
             
            if (x > y)
            {
                if (delta.x > 0)
                    swipeRight = true;
                else 
                    swipeLeft = true;
            }
            else
            {
                if (delta.y > 0)
                    swipeUp = true;
                else
                    swipeDown = true;

            }
        }

        startDrag = Vector2.zero;

    }
    private void OnSartDrag(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        startDrag = touchPosition;
    }
    private void OnPosition(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        touchPosition = ctx.ReadValue<Vector2>();
    }
    private void OnTap(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        tap = true;
    }

    public void OnEnable()
    {
        actionScheme.Enable();
    }
    public void OnDisable()
    {
        actionScheme.Disable();
    }

}


