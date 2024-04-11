namespace Scripts.CodeBase.Infractructure
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMashine _stateMaschine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMashine stateMaschine, SceneLoader sceneLoader)
        {
            _stateMaschine = stateMaschine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("Level1");
        }

        public void Exit()
        {
        }
    }
}