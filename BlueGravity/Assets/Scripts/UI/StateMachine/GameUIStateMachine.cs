using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.UI
{
    public class GameUIStateMachine : StateMachine
    {
        // Start is called before the first frame update
        void Start()
        {
            SwitchState(new GameUINormalState(this));
        }

    }
}


