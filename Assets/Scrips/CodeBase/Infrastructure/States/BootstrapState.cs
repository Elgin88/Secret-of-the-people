using CodeBase.Static;
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
            RegisterServices();
            _sceneLoader.Load(ScenesNames.SceneNameInitialGame, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>("Level1");

        private void RegisterServices() => Game.InputService = RegisterInputService();

        private static IInputService RegisterInputService()
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

        public void Exit()
        {
        }
    }
}