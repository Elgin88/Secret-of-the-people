namespace Scripts.CodeBase.Infractructure
{
    public class LoadLevelState : IEnterablePayloadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = AllServices.Container.Get<IGameFactory>();
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _gameFactory.CreateGraphy();
            SetNextState();
        }

        private void SetNextState()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}