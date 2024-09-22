using Jrpg.GameCore.Core.EventBuses;
using Jrpg.GameCore.Extendables.Events;
using UnityEngine;

namespace Jrpg.Controls
{
    public class InputReader : MonoBehaviour
    {
        private void Update()
        {
            // ReadKey();
            ReadKeyDown();
            ReadAxis();
        }

        private void ReadKey()
        {
            if (Input.GetKey(KeyCode.W))
            {
                var @event = new UpKeyPressed();
                EventBus<UpKeyPressed>.Publish(@event);
            }
            if (Input.GetKey(KeyCode.S))
            {
                var @event = new DownKeyPressed();
                EventBus<DownKeyPressed>.Publish(@event);
            }
            if (Input.GetKey(KeyCode.A))
            {
                var @event = new LeftKeyPressed();
                EventBus<LeftKeyPressed>.Publish(@event);
            }
            if (Input.GetKey(KeyCode.D))
            {
                var @event = new RightKeyPressed();
                EventBus<RightKeyPressed>.Publish(@event);
            }
        }
        
        private void ReadKeyDown()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                var @event = new ExitKeyPressed();
                EventBus<ExitKeyPressed>.Publish(@event);
            }
        }
        
        private void ReadAxis()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            var horizontalEvent = new HorizontalAxisEvent(horizontal);
            var verticalEvent = new VerticalAxisEvent(vertical);

            EventBus<HorizontalAxisEvent>.Publish(horizontalEvent);
            EventBus<VerticalAxisEvent>.Publish(verticalEvent);
        }
    }
}