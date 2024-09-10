using System;
using System.Collections.Generic;
using Jrpg.GameCore.Core.Interfaces;

namespace Jrpg.GameCore.Core.StateMachines
{
    public class StateMachine
    {
        private StateNode _current;
        private Dictionary<Type, StateNode> _nodes = new();
        private HashSet<ITransition> _transitions = new();

        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                ChangeState(transition.TargetState);
            }
            
            _current.State?.Update();
        }

        public void FixedUpdate()
        {
            _current.State?.FixedUpdate();
        }

        public void SetState(IState state)
        {
            if (_nodes.TryGetValue(state.GetType(), out var newState))
            {
                _current = newState;
                _current.State.OnEnter();
            }
        }

        public void ChangeState(IState state)
        {
            if (_current.State == state)
            {
                return;
            }
            
            if (_nodes.TryGetValue(state.GetType(), out var newState))
            {
                _current.State.OnExit();
                _current = newState;
                _current.State.OnEnter();
            }
        }

        public void AddTransition(IState from, IState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }
        
        private ITransition GetTransition()
        {
            foreach (var transition in _transitions)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }
            }

            foreach (var transition in _current.PossibleTransitions)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }
            }

            return null;
        }

        private StateNode GetOrAddNode(IState state)
        {
            var node = _nodes.GetValueOrDefault(state.GetType());

            if (node == null)
            {
                node = new StateNode(state);
                _nodes.Add(state.GetType(), node);
            }

            return node;
        }
        
        private class StateNode
        {
            public IState State { get; }
            public HashSet<ITransition> PossibleTransitions { get; }

            public StateNode(IState state, HashSet<ITransition> possibleTransitions)
            {
                State = state;
                PossibleTransitions = possibleTransitions;
            }

            public StateNode(IState state)
            {
                State = state;
                PossibleTransitions = new HashSet<ITransition>();
            }

            public void AddTransition(ITransition transition)
            {
                PossibleTransitions.Add(transition);
            }

            public void AddTransition(IState targetState, IPredicate condition)
            {
                PossibleTransitions.Add(new Transition(targetState, condition));
            }
        }
    }
}