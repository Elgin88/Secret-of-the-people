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

        public BootstrapState(GameStateMashine state, SceneLoader sceneLoader)
        {
            _stateMachine = state;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            AllServices.Container.RegisterSingle<IInputService>(InputService());
            AllServices.Container.RegisterSingle <IGameFactory>(new GameFactory(AllServices.Container.Single<IAssets>()));
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
    }
}