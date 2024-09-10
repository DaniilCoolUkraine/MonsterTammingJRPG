using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Core.StateMachines;
using Jrpg.GameCore.Extendables.ConcreteStateMachine.States;
using Jrpg.GameCore.Extendables.Predicates;
using UnityEngine;

namespace Jrpg.GameCore.Extendables.ConcreteStateMachine
{
    public class CharacterStateMachine : MonoBehaviour
    {
        [SerializeField] private bool _isMoving;
        private Animator _animator;

        private StateMachine _stateMachine;

        private bool _initialized;
        
        public void Init(Animator animator)
        {
            _stateMachine = new StateMachine();
            _animator = animator;

            var movementState = new MovementState(_animator);
            var idleState = new IdleState(_animator);

            // todo add real conditions
            At(idleState, movementState, new FuncPredicate(() => _isMoving));
            At(movementState, idleState, new FuncPredicate(() => !_isMoving));
            
            _stateMachine.SetState(idleState);
            
            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized)
            {
                return;
            }
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            if (!_initialized)
            {
                return;
            }
            _stateMachine.FixedUpdate();
        }

        private void At(IState from, IState to, IPredicate condition)
        {
            _stateMachine.AddTransition(from, to, condition);
        }
    }
}