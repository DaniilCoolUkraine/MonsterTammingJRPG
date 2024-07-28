using System;

namespace BehTree.Core.EventBus.Bindings
{
    public interface IEventBinding<T>
    {
        public Action<T> OnEvent { get; set; }
        public Action OnEventNoArgs { get; set; }
    }
}