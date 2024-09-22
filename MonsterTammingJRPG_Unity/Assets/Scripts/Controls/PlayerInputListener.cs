using Jrpg.GameCore.Core.EventBuses;
using Jrpg.GameCore.Core.EventBuses.Bindings;
using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.Events;
using UnityEngine;

namespace Jrpg.Controls
{
    public class PlayerInputListener : InputListener
    {
        private IMovementSetter _movementSetter;

        private IEventBinding<UpKeyPressed> _upKeyPressedEvent;
        private IEventBinding<DownKeyPressed> _downKeyPressedEvent;
        private IEventBinding<LeftKeyPressed> _leftKeyPressedEvent;
        private IEventBinding<RightKeyPressed> _rightKeyPressedEvent;

        private IEventBinding<HorizontalAxisEvent> _horizontalAxisEvent;
        private IEventBinding<VerticalAxisEvent> _verticalAxisEvent;

        private float _horizontalAxisValue;
        private float _verticalAxisValue;

        protected override void Awake()
        {
            base.Awake();
            _movementSetter = GetComponent<IMovementSetter>();
        }

        private void Update()
        {
            // todo maybe move to separate class?
            Vector3 moveVector = new Vector3(_horizontalAxisValue, _verticalAxisValue).normalized;
            _movementSetter.SetVelocity(moveVector);
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            
            var upKeyPressedEventBuilder = new EventBinding<UpKeyPressed>.Builder();
            var downKeyPressedEventBuilder = new EventBinding<DownKeyPressed>.Builder();
            var leftKeyPressedEventBuilder = new EventBinding<LeftKeyPressed>.Builder();
            var rightKeyPressedEventBuilder = new EventBinding<RightKeyPressed>.Builder();

            var horizontalAxisEventBuilder = new EventBinding<HorizontalAxisEvent>.Builder();
            var verticalAxisEventBuilder = new EventBinding<VerticalAxisEvent>.Builder();

            _upKeyPressedEvent = upKeyPressedEventBuilder.WithAction(OnUpKeyPressed).Build();
            _downKeyPressedEvent = downKeyPressedEventBuilder.WithAction(OnDownKeyPressed).Build();
            _leftKeyPressedEvent = leftKeyPressedEventBuilder.WithAction(OnLeftKeyPressed).Build();
            _rightKeyPressedEvent = rightKeyPressedEventBuilder.WithAction(OnRightKeyPressed).Build();

            _horizontalAxisEvent = horizontalAxisEventBuilder.WithAction(OnHorizontalAxis).Build();
            _verticalAxisEvent = verticalAxisEventBuilder.WithAction(OnVerticalAxis).Build();
            
            EventBus<UpKeyPressed>.Subscribe(_upKeyPressedEvent);
            EventBus<DownKeyPressed>.Subscribe(_downKeyPressedEvent);
            EventBus<LeftKeyPressed>.Subscribe(_leftKeyPressedEvent);
            EventBus<RightKeyPressed>.Subscribe(_rightKeyPressedEvent);
            
            EventBus<HorizontalAxisEvent>.Subscribe(_horizontalAxisEvent);
            EventBus<VerticalAxisEvent>.Subscribe(_verticalAxisEvent);
        }

        protected override void Dispose()
        {
            base.Dispose();

            EventBus<UpKeyPressed>.Unsubscribe(_upKeyPressedEvent);
            EventBus<DownKeyPressed>.Unsubscribe(_downKeyPressedEvent);
            EventBus<LeftKeyPressed>.Unsubscribe(_leftKeyPressedEvent);
            EventBus<RightKeyPressed>.Unsubscribe(_rightKeyPressedEvent);

            EventBus<HorizontalAxisEvent>.Unsubscribe(_horizontalAxisEvent);
            EventBus<VerticalAxisEvent>.Unsubscribe(_verticalAxisEvent);
        }

        private void OnUpKeyPressed()
        {
            throw new System.NotImplementedException();
        }

        private void OnDownKeyPressed()
        {
            throw new System.NotImplementedException();
        }

        private void OnLeftKeyPressed()
        {
            throw new System.NotImplementedException();
        }

        private void OnRightKeyPressed()
        {
            throw new System.NotImplementedException();
        }
        
        private void OnHorizontalAxis(HorizontalAxisEvent @event)
        {
            _horizontalAxisValue = @event.Value;
        }

        private void OnVerticalAxis(VerticalAxisEvent @event)
        {
            _verticalAxisValue = @event.Value;
        }
    }
}