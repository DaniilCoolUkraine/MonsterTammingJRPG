using Jrpg.GameCore.Core.Interfaces;
using UnityEngine;

namespace Jrpg.Movement
{
    public class ImpulseMovement : MonoBehaviour, IMovementSetter
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
            _rigidbody.AddForce(_direction * _movementSpeed, ForceMode2D.Impulse);
        }
    }
}