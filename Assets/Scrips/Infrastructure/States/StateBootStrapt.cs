using System;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class StateBootStrapt : IState, IEnterableState
    {
        private GameStateMachine _gameStateMachine;
        private AllServices _allServices;

        public StateBootStrapt(GameStateMachine gameStateMachine, AllServices allServices)
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
            _gameStateMachine.Enter<StateLoadLevel, string>(ScenesNames.Level1);
        }
    }
}