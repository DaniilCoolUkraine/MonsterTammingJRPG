using Jrpg.GameCore.Core.Interfaces;
using UnityEngine;

namespace Jrpg.UnitStates
{
    public class UnitStateController : IStateController
    {
        private IState _currentState;

        IState IStateController.CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        public void ChangeState(IState newState)
        {
            if (!ReferenceEquals(_currentState, newState))
            {
                Debug.Log($"change state to {newState.GetType()}");
                _currentState = newState;
            }
        }
    }
}