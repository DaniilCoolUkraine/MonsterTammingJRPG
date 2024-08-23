using System.Linq;
using Cysharp.Threading.Tasks;
using Jrpg.GameCore.Core.EventBuses;
using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.Events;
using Jrpg.GameCore.Extendables.General;
using Jrpg.UnitStates;
using UnityEngine;
using Zenject;

namespace Jrpg.Spawnable.Units
{
    public class UnitBase : SceneSpawnable
    {
        [Inject] private IRuntimeDataProvider _runtimeDataProvider;

        public IAnimationController Animation { get; protected set; }
        public IStateController StateController { get; protected set; }

        private void Update()
        {
            StateController.CurrentState?.Update();
        }

        public override async UniTask<bool> Spawn(int id)
        {
            await Init(id);
            return true;
        }

        private async UniTask<bool> Init(int id)
        {
            InitStateMachine();
            await InitAnimation(id);

            SendEvent();

            return true;
        }

        private async UniTask InitAnimation(int id)
        {
            if (_runtimeDataProvider.UnitsModelStorage.TryGetItem(id, out var model))
            {
                var modelInstantiateProcess = InstantiateAsync(model.Spawnables.Random(), transform);
                await modelInstantiateProcess;
                Animation = modelInstantiateProcess.Result.FirstOrDefault() as IAnimationController;
            }
            else
            {
                Debug.LogError($"cant find model for id {id}");
            }
        }

        private void InitStateMachine()
        {
            StateController = new UnitStateController();
        }

        private void SendEvent()
        {
            var builder = new UnitSpawnedEvent.Builder();
            var @event = builder.WithUnit(this).Build();

            EventBus<UnitSpawnedEvent>.Publish(@event);
        }
    }
}