using Scripts.Canvas;
using Scripts.EnemyComponents;
using Scripts.PlayerComponents;
using Scripts.Static;
using Scripts.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private GameObject _player;
        private GameObject _healthBar;
        private List<GameObject> _weapons = new List<GameObject>();
        private List<GameObject> _clips = new List<GameObject>();

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
            _player = CreateGameObject(StaticAssetPath.Player, GetPosition(StaticTags.PlayerSpawnPoint));
            _player.GetComponent<PlayerInventory>().Construct(this);

            return _player;
        }

        public GameObject CreateCanvasJoystick()
        {
            return _assetProvider.Instantiate(StaticAssetPath.CanvasJoystick);
        }

        public GameObject CreatePlayerHealthBar()
        {
            _healthBar = _assetProvider.Instantiate(StaticAssetPath.CanvasHealthBar);

            _healthBar.GetComponent<HealthBar>().Construct(this);

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

            foreach (var sceletonInitialPoint in skeletonInitialPoints)
            {
                GameObject skeleton = CreateGameObject(StaticAssetPath.Sceleton, sceletonInitialPoint.transform.position);

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
            GameObject gunClip = CreateClip(StaticAssetPath.GunClip);

            gunClip.GetComponent<GunClip>().Construct(this);

            return gunClip;
        }

        public GameObject CreateGunBullet()
        {
            return CreateWeapon(StaticAssetPath.GunBullet);
        }

        private GameObject CreateGameObject(string path, Vector3 position) => _assetProvider.Instantiate(path, position, Quaternion.identity);

        private GameObject CreateGameObject(string path) => _assetProvider.Instantiate(path);

        private Vector3 GetPosition(string tag) => GameObject.FindGameObjectWithTag(tag).transform.position;

        private GameObject CreateClip(string path)
        {
            GameObject clip = CreateGameObject(path);

            _clips.Add(clip);

            return clip;
        }

        private GameObject CreateWeapon(string path)
        {
            GameObject weapon = _assetProvider.Instantiate(path);

            _weapons.Add(weapon);

            return weapon;
        }
    }
}