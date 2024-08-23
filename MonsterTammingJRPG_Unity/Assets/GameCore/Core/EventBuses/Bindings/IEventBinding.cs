using System;

namespace Jrpg.GameCore.Core.EventBuses.Bindings
{
    public interface IEventBinding<T>
    {
        public Action<T> OnEvent { get; set; }
        public Action OnEventNoArgs { get; set; }
    }
}