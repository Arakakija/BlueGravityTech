using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Player
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public InputReader InputReader { get; private set;}
        [field: SerializeField] public Animator Animator { get; private set; }
        
        [field: SerializeField] public Rigidbody2D RB { get; private set;}
        [field: SerializeField] public ForceReceiver ForceReceiver { get; private set;}

        // Start is called before the first frame update
        void Start()
        {
            SwitchState(new PlayerNormalState(this));
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Move(Vector2 motion)
        {
            RB.velocity = motion * PlayerController.Instance.speed;
        }
    }
}
