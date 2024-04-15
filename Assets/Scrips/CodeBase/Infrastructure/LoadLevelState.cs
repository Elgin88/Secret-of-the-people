using CodeBase.Static;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMashine _stateMaschine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoaderCurtain _loaderCurtain;

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

        public void Exit()
        {
            _loaderCurtain.Hide();
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindWithTag(Constants.PlayerInitialPointTag);

            GameObject player = Instantiate(Constants.PlayerPrefabLocation, initialPoint.transform.position);

            CameraFollow(player.transform);

            _stateMaschine.Enter<GameLoopState>();
        }

        private void CameraFollow(Transform transform)
        {
            UnityEngine.Camera.main.GetComponent<CameraFollower>().Follow(transform);
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static GameObject Instantiate(string path, Vector3 position)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}