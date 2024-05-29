namespace Scripts.CodeBase.Infractructure
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