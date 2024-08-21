using Cysharp.Threading.Tasks;
using Jrpg.General;
using Jrpg.Interfaces;
using Jrpg.Spawnable.Units;
using Jrpg.UnitStates.States;
using UnityEngine;

namespace Jrpg.PlayerControlls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerControlledUnit : MonoBehaviour
    {
        [SerializeField] private UnitBase _unit;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;
        
        private float _horizontalInput;
        private float _verticalInput;

        private IState _idleState;
        private WalkState _walkState;
        private IState _attackState;

        private async void Start()
        {
            await new WaitUntil(() => _unit.Animation != null);

            _idleState = new IdleState(_unit.Animation);
            _walkState = new WalkState(_unit.Animation, transform);
        }

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(new Vector2(_horizontalInput, _verticalInput).normalized * _speed, ForceMode2D.Impulse);

            if (Mathf.Abs(_horizontalInput) > SpeedThreshold.IDLE_THRESHOLD || 
                Mathf.Abs(_verticalInput) > SpeedThreshold.IDLE_THRESHOLD)
            {
                _walkState.SetDirection(_horizontalInput);
                _unit.StateController.ChangeState(_walkState);
            }
            else
            {
                _unit.StateController.ChangeState(_idleState);
            }
        }
    }
}