using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.Enums;

namespace Jrpg.UnitStates.States
{
    public class IdleState : IState
    {
        private IAnimationController _controller;

        public IdleState(IAnimationController controller)
        {
            _controller = controller;
        }

        public bool Update()
        {
            _controller.PlayAnimation(EAnimationState.Idle);
            return true;
        }
    }
}