using Scripts.Static;
using System;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private GameObject _player;

        public GameObject Player => _player;

        public Action PlayerLoaded { get; set; }

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateGraphy()
        {
            return _assetProvider.Instantiate(AssetPath.CanvasGraphy);
        }

        public GameObject CreatePlayer()
        {
            Vector3 position = FindObjectByTag(StaticTags.Player);
            _player = CreateGameObject(AssetPath.Player, position);
            PlayerLoaded?.Invoke();

            return _player;
        }

        public GameObject CreateCanvas()
        {
            return _assetProvider.Instantiate(AssetPath.CanvasJoystick);
        }

        public GameObject CreateHealthBar()
        {
            return _assetProvider.Instantiate(AssetPath.CanvasHealthBar);
        }

        public GameObject CreateSkeleton()
        {
            Vector3 position = FindObjectByTag(StaticTags.Enemy);

            return CreateGameObject(AssetPath.Sceleton, position);
        }

        private GameObject CreateGameObject(string path, Vector3 position)
        {
            if (position != null)
            {
                return _assetProvider.Instantiate(path, position, Quaternion.identity);
            }
            else
            {
                return _assetProvider.Instantiate(path);
            }
        }

        private static Vector3 FindObjectByTag(string path) => GameObject.FindGameObjectWithTag(path).transform.position;
    }
}