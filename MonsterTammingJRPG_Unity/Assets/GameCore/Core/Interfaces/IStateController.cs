namespace Jrpg.GameCore.Core.Interfaces
{
    public interface IStateController
    {
        public IState CurrentState { get; protected set; }
        public void ChangeState(IState newState);
    }
}