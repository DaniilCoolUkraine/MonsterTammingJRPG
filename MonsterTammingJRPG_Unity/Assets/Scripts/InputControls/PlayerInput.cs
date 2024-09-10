using System;
using Jrpg.GameCore.Core.Interfaces;
using UnityEngine;

namespace Jrpg.InputControls
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<Vector3> InputChanged; 
        
        private IMovementSetter _movementSetter;

        private void Awake()
        {
            _movementSetter = GetComponent<IMovementSetter>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 moveVector = new Vector3(horizontal, vertical).normalized;

            InputChanged?.Invoke(moveVector);
            _movementSetter.SetVelocity(moveVector);
        }
    }
}