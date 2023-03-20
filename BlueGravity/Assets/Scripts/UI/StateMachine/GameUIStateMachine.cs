using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.UI
{
    public class GameUIStateMachine : StateMachine
    {
        // Start is called before the first frame update
        public GameUINormalState NormalState { get; private set; }
        public GameUIShopState ShopState { get; private set; }

        void Start()
        {
            NormalState = new GameUINormalState(this);
            ShopState = new GameUIShopState(this);
            
            SwitchState(NormalState);
        }

    }
}


