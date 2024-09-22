using Jrpg.GameCore.Core.Interfaces;

namespace Jrpg.GameCore.Extendables.Events
{
    public class UpKeyPressed : IEvent
    {
        public UpKeyPressed(){}
    }

    public class DownKeyPressed : IEvent
    {
        public DownKeyPressed(){}
    }

    public class LeftKeyPressed : IEvent
    {
        public LeftKeyPressed(){}
    }

    public class RightKeyPressed : IEvent
    {
        public RightKeyPressed(){}
    }

    public class ExitKeyPressed : IEvent
    {
        public ExitKeyPressed(){}
    }

    public class HorizontalAxisEvent : IEvent
    {
        public float Value { get; }

        public HorizontalAxisEvent(float value)
        {
            Value = value;
        }
    }

    public class VerticalAxisEvent : IEvent
    {
        public float Value { get; }

        public VerticalAxisEvent(float value)
        {
            Value = value;
        }
    }
}