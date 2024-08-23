using Cysharp.Threading.Tasks;
using Jrpg.GameCore.Core.Interfaces;
using UnityEngine;

namespace Jrpg.Spawnable
{
    public abstract class SceneSpawnable : MonoBehaviour, ISpawnable
    {
        public abstract UniTask<bool> Spawn(int id);
    }
}