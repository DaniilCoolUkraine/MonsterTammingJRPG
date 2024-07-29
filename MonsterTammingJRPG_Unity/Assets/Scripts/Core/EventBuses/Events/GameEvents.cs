using UnityEngine;

namespace Jrpg.Core.EventBuses.Events
{
    public class TestEvent : IEvent
    {
    }

    public class PlayerSpawnedEvent : IEvent
    {
        public Transform Transform { get; protected set; }

        protected PlayerSpawnedEvent()
        {
        }
        
        public class Builder
        {
            private PlayerSpawnedEvent _event = new PlayerSpawnedEvent();
            
            public Builder WithTransform(Transform transform)
            {
                _event.Transform = transform;
                return this;
            }

            public PlayerSpawnedEvent Build()
            {
                return _event;
            }
        }
    }
}