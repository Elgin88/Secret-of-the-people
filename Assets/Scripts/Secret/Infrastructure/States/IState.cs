namespace Secret.Infrastructure.States
{
    public interface IState
    {
        public void Exit();
    }

    public interface IEnterableState : IState
    {
        public void Enter();
    }

    public interface IEnterablePayloadedState<Payload> : IState
    {
        public void Enter(Payload payload);
    }
}