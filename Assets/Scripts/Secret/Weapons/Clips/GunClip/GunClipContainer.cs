using System;
using Secret.Infrastructure.Factory;
using Secret.StaticData;
using Secret.Weapons.Bullets;
using UnityEngine;

namespace Secret.Weapons.Clips.GunClip
{
    public class GunClipContainer : MonoBehaviour, IClipContainer, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private IGameFactory _gameFactory;
        private IBullet _iCurrentBullet;
        private IBulletMover _iCurrentBulletMover;
        private int _currentBulletCount;

        public IBullet ICurrentBullet => _iCurrentBullet;

        public IBulletMover ICurrentBulletMover => _iCurrentBulletMover;

        public int CurrentBulletCount => _currentBulletCount;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void SetICurrentBullet()
        {
        }

        public void AddBullets()
        {
        }
    }
}