using Jrpg.GameCore.Core.Interfaces;
using UnityEngine;

namespace Jrpg.GameCore.Core.StateMachines.States
{
    public class StateBase : IState
    {
        protected const float CROSS_FADE_DURATION = 0.5f;

        protected readonly Animator _animator;

        public StateBase(Animator animator)
        {
            _animator = animator;
        }


        public virtual void OnEnter()
        { 
            // noop
        }

        public virtual void OnExit()
        { 
            // noop
        }

        public virtual void Update()
        { 
            // noop
        }

        public virtual void FixedUpdate()
        { 
            // noop
        }
    }
}