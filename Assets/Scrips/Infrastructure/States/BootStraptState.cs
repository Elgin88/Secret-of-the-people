using System;
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
            RegisterInputSerivece();

            _allServices.Register<IAssetProvider>(new AssetProvider());
            _allServices.Register<IGameFactory>(new GameFactory(AllServices.Container.Get<IAssetProvider>()));
        }

        private void RegisterInputSerivece()
        {
            if (Application.isMobilePlatform)
            {
                _allServices.Register<IInputService>(new MobileInputService());
            }
            else
            {
                _allServices.Register<IInputService>(new StandAloneInputService());
            }
        }

        private void SetNextState()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(ScenesNames.Level1);
        }
    }
}