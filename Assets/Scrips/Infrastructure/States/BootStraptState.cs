using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class BootStraptState : IState, IEnterableState
    {
        private GameStateMachine _gameStateMachine;
        private AllServices _allServices;

        public BootStraptState(GameStateMachine gameStateMachine, AllServices allServices)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = allServices;

            RegisterServices();
        }

        public void Enter()
        {
            SetNextState();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _allServices.Register<IAssetProvider>(new AssetProvider());
            _allServices.Register<IGameFactory>(new GameFactory(AllServices.Container.Get<IAssetProvider>()));
        }

        private void SetNextState()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(ScenesNames.Level1);
        }
    }
}