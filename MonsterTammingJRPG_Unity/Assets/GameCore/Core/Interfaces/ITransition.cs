namespace Jrpg.GameCore.Core.Interfaces
{
    public interface ITransition
    {
        IState TargetState { get; }
        IPredicate Condition { get; }
    }
}