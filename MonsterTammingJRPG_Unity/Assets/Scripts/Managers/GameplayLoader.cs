using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.ConcreteStorages;
using Jrpg.GameCore.Extendables.Storageables;
using Jrpg.Spawnable.Units;
using Jrpg.Spawners;
using UnityEngine;
using Zenject;

namespace Jrpg.Managers
{
    public class GameplayLoader : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private IRuntimeDataProvider _runtimeDataProvider;
        
        private ISpawner<SpawnableDataStorage, SpawnableStorageable, UnitBase> _unitSpawner;

        private void Awake()
        {
            _unitSpawner = new UnitSpawner();
            _unitSpawner.Init(_runtimeDataProvider.UnitStorage, _container);
        }

        private async void Start()
        {
            await _unitSpawner.Spawn(new[] { 0, 1, 2, 2, 2 });
        }
    }
}