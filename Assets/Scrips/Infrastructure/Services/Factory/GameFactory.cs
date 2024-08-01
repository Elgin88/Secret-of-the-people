using System.Collections.Generic;
using Scripts.Canvas;
using Scripts.EnemyComponents;
using Scripts.PlayerComponents;
using Scripts.Static;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public class GameFactory : IGameFactory
    {
        private List<GameObject> _skeletons;
        private IAssetProvider _assetProvider;
        private GameObject _player;
        private GameObject _healthBar;
        private GameObject _gun;
        private GameObject _gunBullet;

        public GameObject Player => _player;

        public GameObject HealthBar => _healthBar;

        public GameObject Gun => _gun;

        public GameObject GunBullet => _gunBullet;

        public GameFactory(IAssetProvider assetProvider) => _assetProvider = assetProvider;

        public GameObject CreateGraphy() => _assetProvider.Instantiate(StaticAssetPath.CanvasGraphy);

        public GameObject CreatePlayer()
        {
            _player = CreateGameObject(StaticAssetPath.Player, GetPosition(StaticTags.PlayerSpawnPoint));

            _player.GetComponent<PlayerChooserWeapon>().Construct(this);

            return _player;
        }

        public GameObject CreateCanvasJoystick() => _assetProvider.Instantiate(StaticAssetPath.CanvasJoystick);

        public GameObject CreateHealthBar(PlayerHealth playerHealth)
        {
            _healthBar = _assetProvider.Instantiate(StaticAssetPath.CanvasHealthBar);

            _healthBar.GetComponent<HealthBar>().Construct(playerHealth);

            return _healthBar;
        }

        public List<GameObject> CreateSkeletons(IGameFactory iGameFactory)
        {
            _skeletons = new List<GameObject>();

            GameObject[] skeletonInitialPoints = GameObject.FindGameObjectsWithTag(StaticTags.SkeletonSpawnPoint);

            if (skeletonInitialPoints.Length == 0)
            {
                return null;
            }

            foreach (var sceletonInitialPoint in skeletonInitialPoints)
            {
                GameObject skeleton = CreateGameObject(StaticAssetPath.Sceleton, sceletonInitialPoint.transform.position);

                skeleton.GetComponent<AgentMoveToPlayer>().Construct(iGameFactory);

                _skeletons.Add(skeleton);
            }

            return _skeletons;
        }

        public GameObject CreateGun()
        {
            _gun = _assetProvider.Instantiate(StaticAssetPath.Gun);
            _gun.GetComponent<Gun>().Construct(this);

            return _gun;
        }

        public GameObject CreateGunBullet()
        {
            _gunBullet = _assetProvider.Instantiate(StaticAssetPath.GunBullet);
            _gunBullet.GetComponent<GunBullet>().Construct(this);

            return _gunBullet;
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

        private static Vector3 GetPosition(string tag) => GameObject.FindGameObjectWithTag(tag).transform.position;
    }
}