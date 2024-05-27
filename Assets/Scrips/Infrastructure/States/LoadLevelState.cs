using Agava.YandexGames;

namespace Scripts.CodeBase.Infractructure
{
    public class LoadLevelState : IEnterablePayloadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = allService.Get<IGameFactory>();
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
            SetSDKGameReady();
            _gameFactory.CreateGraphy();
            SetNextState();
        }

        private static void SetSDKGameReady()
        {
#if !UNITY_EDITOR
            YandexGamesSdk.GameReady();
#endif
        }

        private void SetNextState() => _gameStateMachine.Enter<GameLoopState>();
    }
}