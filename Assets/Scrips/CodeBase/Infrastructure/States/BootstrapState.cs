using CodeBase.Static;
using Scripts.CodeBase.Infractructure.AssetManagement;
using Scripts.CodeBase.Infractructure.Factory;
using Scripts.CodeBase.Infractructure.Services;
using Scripts.CodeBase.Services.Input;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure.State
{
    public class BootstrapState : IState
    {
        private readonly GameStateMashine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootstrapState(GameStateMashine state, SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = state;
            _sceneLoader = sceneLoader;
            _allServices = allServices;

            RegisterServices();
        }
         
        public void Enter()
        {
            _sceneLoader.Load(ScenesNames.InitialGame, EntelLoadLevel);
        }

        public void Exit()
        {
        }

        private static IInputService InputService()
        {
            if (Application.isEditor)
            {
                return new StandaloneInputService();
            }
            else
            {
                return new MobileInputService();
            }
        }

        private void EntelLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(ScenesNames.Level1);
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle(InputService());
            _allServices.RegisterSingle<IAssets>(new AssetProvider());
            _allServices.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.Single<IAssets>()));
        }
    }
}