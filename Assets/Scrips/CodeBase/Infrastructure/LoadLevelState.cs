using CodeBase.Static;
using Scripts.CameraLogic;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMashine _stateMaschine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMashine stateMaschine, SceneLoader sceneLoader)
        {
            _stateMaschine = stateMaschine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindWithTag(Constants.PlayerInitialPointTag);

            GameObject player = Instantiate(Constants.PlayerPrefabLocation, initialPoint.transform.position);

            CameraFollow(player.transform);
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