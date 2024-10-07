using System.Collections.Generic;
using Secret.Infrastructure.Factory;
using Secret.Weapons.StaticData;
using UnityEngine;

namespace Secret.Weapons.GunClip
{
    public class GunClipContainer : MonoBehaviour
    {
        [SerializeField] private WeaponStaticData _staticData;

        public IGameFactory _gameFactory;
        public List<GameObject> _bullets = new List<GameObject>();
        public int _maxBulletCount => _staticData.MaxBulletCount;
        public int _currentBulletCount => _bullets.Count;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void CreateBullets()
        {
            for (int i = 0; i < _maxBulletCount; i++)
            {
                _bullets.Add(_gameFactory.CreateGunBullet());
            }
        }
    }
}