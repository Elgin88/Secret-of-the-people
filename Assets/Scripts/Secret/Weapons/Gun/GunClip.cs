using System.Collections.Generic;
using Secret.Infrastructure.Services.Factory;
using Secret.Weapons.Interfaces;
using Secret.Weapons.StaticData;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunClip : MonoBehaviour, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private List<GameObject> _bullets = new List<GameObject>();
        private IGameFactory _gameFactory;
        private int _bulletCount => _staticData.BulletCount;

        public int BulletCount => _bulletCount;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Fill()
        {
            for (int i = 0; i < BulletCount; i++)
            {
                _bullets.Add(CreateBullet());
            }
        }

        private GameObject CreateBullet() => _gameFactory.CreateGunBullet();

        public IBullet GetBullet()
        {
            RemoveTopBullet();
            throw new System.NotImplementedException();
        }

        private void RemoveTopBullet()
        {
            throw new System.NotImplementedException();
        }
    }
}