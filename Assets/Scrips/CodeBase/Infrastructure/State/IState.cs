namespace Scripts.CodeBase.Infractructure.State
{
    public interface IState : IExitableState
    {
        public void Enter();        
    }

    public interface IExitableState
    {
        public void Exit();
    }

    public interface IPayLoadedState<TPayload> : IExitableState
    {
        public void Enter(TPayload payload);
    }
}