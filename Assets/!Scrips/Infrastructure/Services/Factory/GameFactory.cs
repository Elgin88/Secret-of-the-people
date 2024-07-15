using Scripts.Static;
using System;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private GameObject _player;
        private GameObject _healthBar;

        public GameObject Player => _player;

        public GameObject HealthBar => _healthBar;

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
            _player = CreateGameObject(AssetPath.Player, GetPosition(StaticTags.Player));
            PlayerLoaded?.Invoke();

            return _player;
        }

        public GameObject CreateCanvas()
        {
            return _assetProvider.Instantiate(AssetPath.CanvasJoystick);
        }

        public GameObject CreateHealthBar()
        {
            _healthBar = _assetProvider.Instantiate(AssetPath.CanvasHealthBar);

            return _healthBar;
        }

        public GameObject CreateSkeleton()
        {
            return CreateGameObject(AssetPath.Sceleton, GetPosition(StaticTags.Enemy));
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

        private static Vector3 GetPosition(string path) => GameObject.FindGameObjectWithTag(path).transform.position;
    }
}