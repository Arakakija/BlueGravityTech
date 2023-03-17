using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        private IState _currentState;

        // Update is called once per frame
        void FixedUpdate()
        {
            _currentState.Tick(Time.deltaTime);
        }

        public void SwitchState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
    
}

