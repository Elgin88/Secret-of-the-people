using Agava.YandexGames;
using Infrastructure.Services;
using Infrastructure.Services.Factory;

namespace Infrastructure.States
{
    public class StateLoadLevel : IEnterablePayloadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private IGameFactory _gameFactory;
        private SceneLoader _sceneLoader;

        public StateLoadLevel(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = allService.Get<IGameFactory>();
        }

        public void Enter(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            SetIsGameReadyforSDK();
            CreateObjects();
            SetNextState();
        }

        private void CreateObjects()
        {
            _gameFactory.CreateSkeletons();
            _gameFactory.CreateGraphy();
            _gameFactory.CreateCanvasJoystick();
            _gameFactory.CreatePlayer();
            _gameFactory.CreatePlayerHealthBar();
        }

        private void SetIsGameReadyforSDK()
        {
#if !UNITY_EDITOR
            if (!Game.IsReady)
            {
                YandexGamesSdk.GameReady();
                Game.SetIsReady();
            }
#endif
        }

        private void SetNextState() => _gameStateMachine.Enter<StateGameLoop>();
    }
}