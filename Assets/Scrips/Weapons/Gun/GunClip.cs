using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunClip : MonoBehaviour, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private IGameFactory _iGameFactory;
        private List<GameObject> _bullets = new List<GameObject>();
        private int _bulletCount;

        public int BulletCount => _bulletCount;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
            SetBulletCount();
        }

        private void Start()
        {
            FillClip();
        }

        public void Reload()
        {
        }

        public void RemoveBullet()
        {
        }

        private GameObject CreateBullet() => _iGameFactory.CreateGunBullet();

        private void AddBulletInClip(GameObject bullet) => _bullets.Add(bullet);

        private void SetBulletCount() => _bulletCount = _staticData.BulletCount;

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void FillClip()
        {
            for (int i = 0; i < _bulletCount; i++)
            {
                AddBulletInClip(CreateBullet());
            }
        }
    }
}