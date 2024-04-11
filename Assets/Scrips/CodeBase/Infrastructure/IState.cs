namespace Scripts.CodeBase.Infractructure
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}