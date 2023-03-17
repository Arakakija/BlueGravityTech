using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour,PlayerActions.IPlayerControlsActions
{
    public event Action OnInteractEvent;
    private PlayerActions _actions;

    public Vector2 MovementValue { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _actions = new PlayerActions();
        _actions.PlayerControls.SetCallbacks(this);
        _actions.PlayerControls.Enable();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        OnInteractEvent?.Invoke();
    }
}
