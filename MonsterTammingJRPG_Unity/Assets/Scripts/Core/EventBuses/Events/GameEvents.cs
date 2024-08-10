using Jrpg.Spawnable.Units;

namespace Jrpg.Core.EventBuses.Events
{
    public class UnitSpawnedEvent : IEvent
    {
        public UnitBase Unit { get; protected set; }

        protected UnitSpawnedEvent()
        {
        }

        public class Builder
        {
            private UnitSpawnedEvent _event = new UnitSpawnedEvent();

            public Builder WithUnit(UnitBase unit)
            {
                _event.Unit = unit;
                return this;
            }

            public UnitSpawnedEvent Build()
            {
                return _event;
            }
        }
    }
}