using Scripts.CodeBase.Services.Input;
using System;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMashine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private const string _initialGame = "InitialGame";

        public BootstrapState(GameStateMashine state, SceneLoader sceneLoader)
        {
            _stateMachine = state;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(_initialGame, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState>();

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

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