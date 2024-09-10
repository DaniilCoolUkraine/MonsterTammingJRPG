using Jrpg.GameCore.Core.StateMachines.States;
using UnityEngine;

namespace Jrpg.GameCore.Extendables.ConcreteStateMachine.States
{
    public class IdleState : StateBase
    {
        private static readonly int _idleHash = Animator.StringToHash("Idle");
        
        public IdleState(Animator animator) : base(animator)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            _animator.CrossFade(_idleHash, CROSS_FADE_DURATION);
        }
    }
}