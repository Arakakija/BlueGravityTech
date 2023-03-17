using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour,PlayerActions.IPlayerControlsActions
{
    private PlayerActions _actions;
    
    public Vector2 MovementValue { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _actions = new PlayerActions();
        _actions.PlayerControls.SetCallbacks(this);
        _actions.PlayerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
}
