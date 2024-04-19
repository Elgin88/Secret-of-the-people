using CodeBase.Static;
using Scripts.CodeBase.Infractructure.Factory;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure.State
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMashine _stateMaschine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoaderCurtain _loaderCurtain;
        private readonly IGameFactory _iGameFactory;

        public LoadLevelState(GameStateMashine stateMaschine, SceneLoader sceneLoader, LoaderCurtain loaderCurtain)
        {
            _stateMaschine = stateMaschine;
            _sceneLoader = sceneLoader;
            _loaderCurtain = loaderCurtain;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
            _loaderCurtain.Show();
        }

        public void Exit() => _loaderCurtain.Hide();

        private void OnLoaded()
        {
            CreatePlayer();
            CreateHud();

            _stateMaschine.Enter<GameLoopState>();
        }

        private void CreateHud()
        {
            _iGameFactory.CreateHud();
        }

        private void CreatePlayer()
        {
            GameObject player = _iGameFactory.CreateHero(GameObject.FindWithTag(Tags.PlayerInitialPointTag));

            CameraFollow(player.transform);
        }

        private void CameraFollow(Transform transform) =>
            Camera.main.GetComponent<CameraFollower>().Follow(transform);

    }
}