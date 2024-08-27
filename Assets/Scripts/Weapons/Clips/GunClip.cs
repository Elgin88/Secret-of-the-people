﻿using System.Collections.Generic;
using Infrastructure.Services.Factory;
using Player;
using StaticData;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons.Clips
{
    public class GunClip : MonoBehaviour, IClip
    {
        [SerializeField] private EnemyStaticData _staticData;

        private readonly string _gunClip = StaticWeapon.GunClip;
        private List<GameObject> _bullets = new List<GameObject>();
        private IGameFactory _gameFactory;
        private int _bulletCount;

        public string Name => _gunClip;

        public int BulletCount => _bulletCount;

        public void Construct(IGameFactory gameFactory)
        {
            SetIGameFactory(gameFactory);
            SetBulletCount();
            FillClip();
        }

        public void Fill()
        {
        }

        public IBullet GetTopBullet()
        {
            if (_bullets.Count == 0)
            {
                return null;
            }

            return _bullets[0].GetComponent<IBullet>();
        }

        public void RemoveTopBullet()
        {
            _bullets.Remove(_bullets[0]);

            if (_bullets.Count == 0)
            {
                _gameFactory.Player.GetComponent<ChooserWeapon>().CurrentWeapon.Reload();
            }
        }

        public int GetBulletCurrentCount() => _bullets.Count;

        private GameObject CreateBullet() => _gameFactory.CreateGunBullet();

        private void AddBulletInClip(GameObject bullet) => _bullets.Add(bullet);

        private void SetBulletCount() => _bulletCount = _staticData.BulletCount;

        private void SetIGameFactory(IGameFactory iGameFactory) => _gameFactory = iGameFactory;

        private void FillClip()
        {
            for (int i = 0; i < _bulletCount; i++)
            {
                AddBulletInClip(CreateBullet());
            }
        }
    }
}