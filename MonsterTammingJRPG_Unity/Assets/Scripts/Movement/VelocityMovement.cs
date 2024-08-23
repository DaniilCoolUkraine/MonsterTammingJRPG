using Jrpg.GameCore.Core.Interfaces;
using UnityEngine;

namespace Jrpg.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VelocityMovement : MonoBehaviour, IMovementSetter
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _movementSpeed;

        private Vector3 _direction;

        public void SetVelocity(Vector3 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _direction * _movementSpeed;
        }
    }
}