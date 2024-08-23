using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.Enums;
using Jrpg.GameCore.Extendables.General;
using UnityEngine;

namespace Jrpg.UnitStates.States
{
    public class WalkState : IState
    {
        private IAnimationController _controller;
        private Transform _transform;

        public WalkState(IAnimationController controller, Transform transform)
        {
            _controller = controller;
            _transform = transform;
        }

        public bool Update()
        {
            _controller.PlayAnimation(EAnimationState.Walk);
            return true;
        }

        public void SetDirection(float horizontalInput)
        {
            if (Mathf.Abs(horizontalInput) > SpeedThreshold.IDLE_THRESHOLD)
            {
                if (Mathf.Sign(horizontalInput) > 0)
                {
                    _transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    _transform.localScale = Vector3.one;
                }
            }
        }
    }
}