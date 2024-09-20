using System.Collections.Generic;
using Canvas;
using Enemy.AI.Agents;
using Infrastructure.Services.AssetManagement;
using Player;
using Static;
using UnityEngine;
using Weapons.Clips;
using Weapons.GunBullet;
using Weapons.GunComponents;

namespace Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private GameObject _player;
        private GameObject _healthBar;

        public GameObject Player => _player;

        public GameObject HealthBar => _healthBar;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateGraphy()
        {
            return _assetProvider.Instantiate(StaticAssetPath.CanvasGraphy);
        }

        public GameObject CreatePlayer()
        {
            _player = CreateGameObject(StaticAssetPath.Player, GetPositionByTag(StaticTags.PlayerSpawnPoint));

            _player.GetComponent<Inventory>().Construct(this);

            return _player;
        }

        public GameObject CreateCanvasJoystick()
        {
            return _assetProvider.Instantiate(StaticAssetPath.CanvasJoystick);
        }

        public GameObject CreatePlayerHealthBar()
        {
            _healthBar = _assetProvider.Instantiate(StaticAssetPath.CanvasHealthBar);

            _healthBar.GetComponent<PlayerHealthBar>().Construct(this);

            return _healthBar;
        }

        public List<GameObject> CreateSkeletons()
        {
            List<GameObject> skeletons = new List<GameObject>();

            GameObject[] skeletonInitialPoints = GameObject.FindGameObjectsWithTag(StaticTags.SkeletonSpawnPoint);

            if (skeletonInitialPoints.Length == 0)
            {
                return null;
            }

            foreach (var point in skeletonInitialPoints)
            {
                GameObject skeleton = CreateGameObject(StaticAssetPath.Sceleton, point.transform.position);

                skeleton.GetComponent<AgentMoveToPlayer>().Construct(this);

                skeletons.Add(skeleton);
            }

            return skeletons;
        }

        public GameObject CreateGun()
        {
            GameObject gun = _assetProvider.Instantiate(StaticAssetPath.Gun);

            gun.GetComponent<Gun>().Construct(this);

            return gun;
        }

        public GameObject CreateGunClip()
        {
            GameObject gunClip = CreateGameObject(StaticAssetPath.GunClip);

            gunClip.GetComponent<GunClip>().Construct(this);

            return gunClip;
        }

        public GameObject CreateGunBullet()
        {
            GameObject bullet = CreateGameObject(StaticAssetPath.GunBullet);

            bullet.GetComponent<Bullet>().Construct(this);

            return bullet;
        }

        private GameObject CreateGameObject(string path, Vector3 position) => _assetProvider.Instantiate(path, position, Quaternion.identity);

        private GameObject CreateGameObject(string path) => _assetProvider.Instantiate(path);

        private Vector3 GetPositionByTag(string tag) => GameObject.FindGameObjectWithTag(tag).transform.position;
    }
}