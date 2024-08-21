using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Jrpg.DataStorage;
using Jrpg.DataStorage.Storageables;
using Jrpg.Interfaces;
using Jrpg.Spawnable.Units;
using UnityEngine;
using Zenject;

namespace Jrpg.Spawners
{
    public class UnitSpawner : ISpawner<SpawnableDataStorage, SpawnableStorageable, UnitBase>
    {
        private SpawnableDataStorage _spawnableStorage;
        private DiContainer _container;
        
        public void Init(SpawnableDataStorage dataStorage, DiContainer container)
        {
            _spawnableStorage = dataStorage;
            _container = container;
        }

        public async UniTask<IEnumerable<UnitBase>> Spawn(IEnumerable<int> requestedIds)
        {
            var instantiatedElements = new List<UnitBase>();
            
            foreach (var id in requestedIds)
            {
                if (_spawnableStorage.TryGetItem(id, out var storageable))
                {
                    var instantiated = _container.InstantiatePrefab(storageable.Spawnable).GetComponent<ISpawnable>();
                    await instantiated.Spawn(id);
                    instantiatedElements.Add(instantiated as UnitBase);
                }
                else
                {
                    Debug.LogError($"cant find spawnable for id {id}");
                }
            }

            return instantiatedElements;
        }
    }
}