using BehTree.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BehTree.Spawnable
{
    public abstract class SceneSpawnable : MonoBehaviour, ISpawnable
    {
        public abstract UniTask<bool> Spawn(int id);
    }
}