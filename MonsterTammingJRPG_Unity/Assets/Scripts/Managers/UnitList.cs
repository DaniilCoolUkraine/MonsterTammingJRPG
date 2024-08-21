using System;
using System.Collections.Generic;
using Jrpg.Core.EventBuses;
using Jrpg.Core.EventBuses.Bindings;
using Jrpg.Core.EventBuses.Events;
using Jrpg.Interfaces;
using Jrpg.Spawnable.Units;
using UnityEngine;

namespace Jrpg.Managers
{
    public class UnitList : MonoBehaviour, IUnitList
    {
        private EventBinding<UnitSpawnedEvent> _playerSpawnedEvent;

        private List<UnitBase> _spawnedUnits;
        
        private void Awake()
        {
            _spawnedUnits = new List<UnitBase>();
            
            var playerSpawnedEventBuilder = new EventBinding<UnitSpawnedEvent>.Builder();
            _playerSpawnedEvent = playerSpawnedEventBuilder.WithAction(OnPlayerSpawned).Build();

            EventBus<UnitSpawnedEvent>.Subscribe(_playerSpawnedEvent);
        }

        private void OnDestroy()
        {
            EventBus<UnitSpawnedEvent>.Unsubscribe(_playerSpawnedEvent);
        }
        
        private void OnPlayerSpawned(UnitSpawnedEvent @event)
        {
            _spawnedUnits.Add(@event.Unit);
        }
    }
}