using Jrpg.GameCore.Core.StateMachines.States;
using UnityEngine;

namespace Jrpg.GameCore.Extendables.ConcreteStateMachine.States
{
    public class MovementState : StateBase
    {
        private static readonly int _movementHash = Animator.StringToHash("Walk");

        public MovementState(Animator animator) : base(animator)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _animator.CrossFade(_movementHash, CROSS_FADE_DURATION);
        }

        public override void Update()
        {
            base.Update();
            
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
        }
    }
}