using Jrpg.GameCore.Core.EventBuses;
using Jrpg.GameCore.Core.EventBuses.Bindings;
using Jrpg.GameCore.Extendables.Events;
using UnityEngine;

namespace Jrpg.Controls
{
    public class InputListener : MonoBehaviour
    {
        private IEventBinding<ExitKeyPressed> _exitKeyPressedEvent;

        protected virtual void Awake()
        {
            Subscribe();
        }

        protected virtual void OnDestroy()
        {
            Dispose();
            EventBus<ExitKeyPressed>.Unsubscribe(_exitKeyPressedEvent);
        }

        protected virtual void Subscribe()
        {
            var upKeyPressedEventBuilder = new EventBinding<ExitKeyPressed>.Builder();
            _exitKeyPressedEvent = upKeyPressedEventBuilder.WithAction(OnExitKeyPressed).Build();
            EventBus<ExitKeyPressed>.Subscribe(_exitKeyPressedEvent);
        }

        protected virtual void Dispose()
        {
        }
        
        private void OnExitKeyPressed()
        {
            if (enabled)
            {
                Dispose();
                this.enabled = false;
            }
            else
            {
                Subscribe();
                this.enabled = true;
            }
        }
    }
}