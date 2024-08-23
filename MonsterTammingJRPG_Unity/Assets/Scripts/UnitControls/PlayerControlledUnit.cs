using Cysharp.Threading.Tasks;
using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.General;
using Jrpg.InputControls;
using Jrpg.Spawnable.Units;
using Jrpg.UnitStates.States;
using UnityEngine;

namespace Jrpg.UnitControls
{
    public class PlayerControlledUnit : MonoBehaviour
    {
        [SerializeField] private UnitBase _unit;
        [SerializeField] private PlayerInput _playerInput;

        private IState _idleState;
        private WalkState _walkState;
        private IState _attackState;

        private void OnEnable()
        {
            _playerInput.InputChanged += OnInputChanged;
        }

        private void OnDisable()
        {
            _playerInput.InputChanged -= OnInputChanged;
        }

        private async void Start()
        {
            await new WaitUntil(() => _unit.Animation != null);

            _idleState = new IdleState(_unit.Animation);
            _walkState = new WalkState(_unit.Animation, transform);
        }

        private void OnInputChanged(Vector3 input)
        {
            if (Mathf.Abs(input.x) > SpeedThreshold.IDLE_THRESHOLD || 
                Mathf.Abs(input.y) > SpeedThreshold.IDLE_THRESHOLD)
            {
                _walkState.SetDirection(input.x);
                _unit.StateController.ChangeState(_walkState);
            }
            else
            {
                _unit.StateController.ChangeState(_idleState);
            }
        }
    }
}