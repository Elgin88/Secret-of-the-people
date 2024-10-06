using System.Collections.Generic;
using Secret.Canvas;
using Secret.Enemy.AI.Agents;
using Secret.Enemy.AI.Agents.Checkers;
using Secret.Infrastructure.Services.AssetManagement;
using Secret.Player.Inventory;
using Secret.Static;
using UnityEngine;

namespace Secret.Infrastructure.Factory
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

            _player.GetComponent<WeaponAdder>().Construct();
            _player.GetComponent<WeaponContainer>().Construct(this);
            _player.GetComponent<WeaponContainer>().AddGun();
            
            _player.GetComponent<WeaponContainer>().AddClip();
            _player.GetComponent<WeaponContainer>().AddClip();
            _player.GetComponent<WeaponContainer>().AddClip();

            _player.GetComponent<WeaponContainer>().AddBulletsInClip();

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
                GameObject skeleton = CreateGameObject(StaticAssetPath.Skeleton, point.transform.position);

                skeleton.GetComponent<AgentMoveToPlayer>().Construct(this);
                skeleton.GetComponent<CheckerAgro>().Construct(this);
                skeleton.GetComponent<CheckerAttackRange>().Construct(this);

                skeletons.Add(skeleton);
            }

            return skeletons;
        }

        public GameObject CreateGun()
        {
            GameObject gun = CreateGameObject(StaticAssetPath.Gun);

            return gun;
        }

        public GameObject CreateGunBullet()
        {
            return CreateGameObject(StaticAssetPath.GunBullet);
        }

        public GameObject CreateGunClip()
        {
            GameObject gunClip = CreateGameObject(StaticAssetPath.GunClip);

            return gunClip;
        }

        private GameObject CreateGameObject(string path, Vector3 position) => _assetProvider.Instantiate(path, position, Quaternion.identity);

        private GameObject CreateGameObject(string path) => _assetProvider.Instantiate(path);

        private Vector3 GetPositionByTag(string tag) => GameObject.FindGameObjectWithTag(tag).transform.position;
    }
}