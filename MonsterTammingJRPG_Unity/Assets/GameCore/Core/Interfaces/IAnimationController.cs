using Jrpg.GameCore.Extendables.Enums;
using UnityEngine;

namespace Jrpg.GameCore.Core.Interfaces
{
    public interface IAnimationController
    {
        public Animator Animator { get; }
        public void PlayAnimation(EAnimationState state);
    }
}