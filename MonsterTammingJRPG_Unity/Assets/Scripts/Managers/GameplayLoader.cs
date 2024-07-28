﻿using Jrpg.DataStorage;
using Jrpg.DataStorage.Storageables;
using Jrpg.Interfaces;
using Jrpg.Spawners;
using UnityEngine;
using Zenject;

namespace Jrpg.Managers
{
    public class GameplayLoader : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private IRuntimeDataProvider _runtimeDataProvider;
        
        private ISpawner<SpawnableDataStorage, SpawnableStorageable> _unitSpawner;

        private void Awake()
        {
            _unitSpawner = new SpawnerBase();
            _unitSpawner.Init(_runtimeDataProvider.UnitStorage, _container);
        }

        private async void Start()
        {
            var unitsSpawned = await _unitSpawner.Spawn(new[] { 0, 1, 2, 2, 2 });

            // here is shit
            // K in spawner is storageable so i need to find another way to get spawned elements
            foreach (var unit in unitsSpawned)
            {
                
            }
        }
    }
}