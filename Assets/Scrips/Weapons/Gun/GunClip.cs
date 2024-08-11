using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunClip : MonoBehaviour, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private IGameFactory _iGameFactory;
        private List<GameObject> _bullets = new List<GameObject>();
        private int _maxBulletCount;

        public int MaxBulletsCount => _maxBulletCount;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
            SetMaxBulletCount();
        }

        public void Reload()
        {
        }

        public void RemoveBullet()
        {
        }

        private void AddBulletsInClip()
        {
            for (int i = 0; i < _maxBulletCount; i++)
            {
                GameObject bullet = _iGameFactory.CreateGunBullet();
                bullet.GetComponent<GunBullet>().Construct(_iGameFactory);
                _bullets.Add(bullet);

            }
        }

        private void SetMaxBulletCount() => _maxBulletCount = _staticData.CountBulletsInClip;

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;
    }
}