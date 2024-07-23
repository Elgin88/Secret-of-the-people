using System;
using System.Collections.Generic;
using Scripts.Canvas;
using Scripts.EnemyComponents;
using Scripts.Static;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private GameObject _player;
        private GameObject _healthBar;
        private List<GameObject> _skeletons;

        public GameObject Player => _player;

        public GameObject HealthBar => _healthBar;

        public List<GameObject> Skeletons => _skeletons;

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
            _player = CreateGameObject(AssetPath.Player, GetPosition(StaticTags.PlayerInitialPoint));

            return _player;
        }

        public GameObject CreateCanvasJoystick() => _assetProvider.Instantiate(AssetPath.CanvasJoystick);

        public GameObject CreateHealthBar(IGameFactory iGameFactory)
        {
            _healthBar = _assetProvider.Instantiate(AssetPath.CanvasHealthBar);

            _healthBar.GetComponent<HealthBar>().Construct(iGameFactory);

            return _healthBar;
        }

        public List<GameObject> CreateSkeletons(IGameFactory iGameFactory)
        {
            _skeletons = new List<GameObject>();

            GameObject[] skeletonInitialPoints = GameObject.FindGameObjectsWithTag(StaticTags.SkeletonInitialPoint);

            if (skeletonInitialPoints.Length == 0)
            {
                return null;
            }

            foreach (var sceletonInitialPoint in skeletonInitialPoints)
            {
                GameObject skeleton = CreateGameObject(AssetPath.Sceleton, sceletonInitialPoint.transform.position);

                skeleton.GetComponent<AgentMoveToPlayer>().Construct(iGameFactory);

                _skeletons.Add(skeleton);
            }

            return _skeletons;
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