using Agava.YandexGames;
using Scripts.Enemy;
using System.Collections.Generic;
using Enemy.Agents.Attack;
using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

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
            CreateCkeletons();

            _iGameFactory.CreateGraphy();
            _iGameFactory.CreateCanvasJoystick();
            _iGameFactory.CreatePlayer();
            _iGameFactory.CreatePlayerHealthBar();
        }

        private void CreateCkeletons()
        {
            List<GameObject> skeletons = _iGameFactory.CreateSkeletons();

            foreach (var skeleton in skeletons)
            {
                skeleton.GetComponent<AgentAttack>().Construct(_iGameFactory);
            }
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