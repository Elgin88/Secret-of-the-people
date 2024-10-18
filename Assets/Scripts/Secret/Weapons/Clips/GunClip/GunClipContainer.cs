using System.Collections.Generic;
using Secret.Infrastructure.Factory;
using Secret.StaticData;
using Secret.Weapons.Weapons.Gun;
using UnityEngine;

namespace Secret.Weapons.Clips.GunClip
{
    public class GunClipContainer : MonoBehaviour, IClipContainer, IGun
    {
        [SerializeField] private WeaponStaticData _staticData;

        public List<GameObject> _bullets = new List<GameObject>();
        private IGameFactory _gameFactory;

        public int BulletCount => _bullets.Count;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;

            Fill();
        }

        public void Fill()
        {
            for (int i = 0; i < _staticData.MaxBulletCount; i++)
            {
                _bullets.Add(_gameFactory.CreateGunBullet());
            }
        }
    }
}