namespace Scripts.CodeBase.Infractructure
{
    public interface IEnterableState : IState
    {
        public void Enter();
    }
}