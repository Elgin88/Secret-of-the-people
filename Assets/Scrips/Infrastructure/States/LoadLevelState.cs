using Scripts.CodeBase.Infractructure.Factory;
using Scripts.Logic;
using Scripts.Static;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure.State
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMashine _stateMaschine;
        private readonly SceneLoader _sceneLoader;
        private readonly CurtainShower _curtainShower;
        private readonly IGameFactory _iGameFactory;

        public LoadLevelState(GameStateMashine stateMaschine, SceneLoader sceneLoader, CurtainShower curtainShower, IGameFactory iGameFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainShower = curtainShower;
            _stateMaschine = stateMaschine;
            _iGameFactory = iGameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtainShower.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtainShower.Hide();
        }

        private void OnLoaded()
        {
            GameObject player = _iGameFactory.CreatePlayer(GameObject.FindWithTag(Tags.PlayerInitialPointTag));

            _iGameFactory.CreateCurtain();

            CameraFollow(player.transform);

            _stateMaschine.Enter<GameLoopState>();
        }

        private void CameraFollow(Transform transform) =>
            Camera.main.GetComponent<CameraFollower>().Follow(transform);
    }
}