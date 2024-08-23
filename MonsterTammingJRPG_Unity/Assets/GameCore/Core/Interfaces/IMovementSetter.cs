using UnityEngine;

namespace Jrpg.GameCore.Core.Interfaces
{
    public interface IMovementSetter
    {
        public void SetVelocity(Vector3 direction);
    }
}