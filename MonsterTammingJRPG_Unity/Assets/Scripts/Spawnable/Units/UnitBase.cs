using System.Linq;
using BehTree.General;
using BehTree.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BehTree.Spawnable.Units
{
    public class UnitBase : SceneSpawnable
    {
        [Inject] private IRuntimeDataProvider _runtimeDataProvider;
        
        private UnitAnimation _animation;

        public override async UniTask<bool> Spawn(int id)
        {
            await Init(id);
            return true;
        }

        private async UniTask<bool> Init(int id)
        {
            if (_runtimeDataProvider.UnitsModelStorage.TryGetItem(id, out var model))
            {
                var modelInstantiateProcess = InstantiateAsync(model.Spawnables.Random(), transform);
                await modelInstantiateProcess;
                _animation = modelInstantiateProcess.Result.FirstOrDefault() as UnitAnimation;

                _animation.transform.position = Vector3.zero;
                _animation.transform.rotation = Quaternion.identity;
                _animation.transform.localScale = Vector3.one;
            }
            else
            {
                Debug.LogError($"cant find model for id {id}");
            }

            return true;
        }
    }
}