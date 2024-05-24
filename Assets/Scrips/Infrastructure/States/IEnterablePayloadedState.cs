namespace Scripts.CodeBase.Infractructure
{
    public interface IEnterablePayloadedState<Payload> : IState
    {
        public void Enter(Payload payload);
    }
}