using Cysharp.Threading.Tasks;
using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.Enums;
using UnityEngine;

namespace Jrpg.Spawnable.Units
{
    public class UnitAnimation : SceneSpawnable, IAnimationController
    {
        [SerializeField] private Animator _animator;

        private EAnimationState _currentState;
        
        public override async UniTask<bool> Spawn(int id)
        {
            throw new System.NotImplementedException();
        }

        public void PlayAnimation(EAnimationState state)
        {
            if (_currentState != state)
            {
                switch (state)
                {
                    case EAnimationState.Idle:
                        PlayIdle();
                        break;
                    case EAnimationState.Walk:
                        PlayWalk();
                        break;
                    default:
                        Debug.LogError($"Unhadled animation state {state}");
                        break;
                }
            }
        }

        private void PlayIdle()
        {
            _currentState = EAnimationState.Idle;
            _animator.SetTrigger("Idle");
        }
        
        private void PlayWalk()
        {
            _currentState = EAnimationState.Walk;
            _animator.SetTrigger("Walk");
        }
    }
}