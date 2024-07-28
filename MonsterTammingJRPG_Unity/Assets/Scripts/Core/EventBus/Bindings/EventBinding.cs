﻿using System;

namespace BehTree.Core.EventBus.Bindings
{
    public abstract class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        private Action<T> _onEvent = _ => { };
        private Action _onEventNoArgs = () => { };

        #region IEventBinding implementation

        Action<T> IEventBinding<T>.OnEvent
        {
            get => _onEvent;
            set => _onEvent = value;
        }

        Action IEventBinding<T>.OnEventNoArgs
        {
            get => _onEventNoArgs;
            set => _onEventNoArgs = value;
        }

        #endregion

        // constructors were made protected in order to create event bindings through inner Builder class
        #region Constructors
        
        protected EventBinding(Action<T> action)
        {
            _onEvent = action;
        }

        protected EventBinding(Action action)
        {
            _onEventNoArgs = action;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Subscribes extra action with parameters
        /// </summary>
        /// <param name="action">Action to invoke on event raised</param>
        public void Add(Action<T> action)
        {
            _onEvent += action;
        }

        /// <summary>
        /// Subscribes extra action without parameters
        /// </summary>
        /// <param name="action">Action to invoke on event raised</param>
        public void Add(Action action)
        {
            _onEventNoArgs += action;
        }

        /// <summary>
        /// Removes action with parameters
        /// </summary>
        /// <param name="action">Action to remove</param>
        public void Remove(Action<T> action)
        {
            _onEvent -= action;
        }

        /// <summary>
        /// Removes action with parameters
        /// </summary>
        /// <param name="action">Action to remove</param>
        public void Remove(Action action)
        {
            _onEventNoArgs -= action;
        }

        #endregion
    }
}