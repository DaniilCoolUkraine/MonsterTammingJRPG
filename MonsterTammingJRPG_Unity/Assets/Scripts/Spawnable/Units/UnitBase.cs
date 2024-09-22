using System.Linq;
using Cysharp.Threading.Tasks;
using Jrpg.GameCore.Core.EventBuses;
using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.ConcreteStateMachine;
using Jrpg.GameCore.Extendables.Events;
using Jrpg.GameCore.Extendables.General;
using UnityEngine;
using Zenject;

namespace Jrpg.Spawnable.Units
{
    public class UnitBase : SceneSpawnable
    {
        [SerializeField] private CharacterStateMachine _stateMachine;
        
        [Inject] private IRuntimeDataProvider _runtimeDataProvider;

        public Animator Animator { get; protected set; }

        public override async UniTask<bool> Spawn(int id)
        {
            await Init(id);
            return true;
        }

        private async UniTask<bool> Init(int id)
        {
            await InitAnimation(id);
            InitStateMachine(Animator);

            SendEvent();

            return true;
        }

        private void InitStateMachine(Animator animator)
        {
            _stateMachine.Init(animator);
        }

        private async UniTask InitAnimation(int id)
        {
            if (_runtimeDataProvider.UnitsModelStorage.TryGetItem(id, out var model))
            {
                var modelInstantiateProcess = InstantiateAsync(model.Spawnables.Random(), transform);
                await modelInstantiateProcess;
                Animator = modelInstantiateProcess.Result.FirstOrDefault()?.GetComponent<Animator>();
            }
            else
            {
                Debug.LogError($"cant find model for id {id}");
            }
        }

        private void SendEvent()
        {
            var builder = new UnitSpawnedEvent.Builder();
            var @event = builder.WithUnit(this).Build();

            EventBus<UnitSpawnedEvent>.Publish(@event);
        }
    }
}