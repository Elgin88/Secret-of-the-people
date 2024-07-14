using Agava.YandexGames;

namespace Scripts.CodeBase.Logic
{
    public class StateLoadLevel : IEnterablePayloadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private IGameFactory _iGameFactory;

        public StateLoadLevel(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _iGameFactory = allService.Get<IGameFactory>();
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
            TrySetIsGameReadyforSDK();
            CreateObjects();
            SetNextState();
        }

        private void CreateObjects()
        {
            _iGameFactory.CreateGraphy();
            _iGameFactory.CreatePlayer();
            _iGameFactory.CreateCanvas();
            _iGameFactory.CreateHealthBar();
        }

        private void TrySetIsGameReadyforSDK()
        {
#if !UNITY_EDITOR
            if (!Game.IsReady)
            {
                YandexGamesSdk.GameReady();
                Game.SetIsReadyTrue();
            }
#endif
        }

        private void SetNextState() => _gameStateMachine.Enter<StateGameLoop>();
    }
}