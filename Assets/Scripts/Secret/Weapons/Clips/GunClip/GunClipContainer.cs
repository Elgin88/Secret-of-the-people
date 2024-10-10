using System.Collections.Generic;
using Secret.Infrastructure.Factory;
using Secret.StaticData;
using Secret.Weapons.Bullets.GunBullet;
using UnityEngine;

namespace Secret.Weapons.Clips.GunClip
{
    public class GunClipContainer : MonoBehaviour, IClip, IClipContainer
    {
        [SerializeField] private WeaponStaticData _staticData;

        private IGameFactory _gameFactory;
        private List<GameObject> _bullets = new List<GameObject>();
        private int _maxBulletCount => _staticData.MaxBulletCount;

        public int BulletCount => _bullets.Count;
        
        public int CurrentBulletCount { get; set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            
            Debug.Log("Удалить эту строчку");
        }

        public void AddBullets()
        {
            for (int i = 0; i < _maxBulletCount; i++)
            {
                _bullets.Add(_gameFactory.CreateGunBullet());
            }
        }

        public GunBulletMover GetBulletMover()
        {
            GunBulletMover gunBulletMover = null;

            if (_bullets.Count > 0)
            {
                gunBulletMover = _bullets[0].GetComponent<GunBulletMover>();
                _bullets.Remove(_bullets[0]);
            }

            return gunBulletMover;
        }

        
    }
}