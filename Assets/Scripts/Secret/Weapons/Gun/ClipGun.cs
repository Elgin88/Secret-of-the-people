using System.Collections.Generic;
using Secret.Infrastructure.Services.Factory;
using Secret.Weapons.Interfaces;
using Secret.Weapons.StaticData;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class ClipGun : MonoBehaviour, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private List<GameObject> _bullets = new List<GameObject>();
        private IGameFactory _gameFactory;

        public int MaxBulletCount => _staticData.MaxBulletCount;

        public int CurrentBulletCount => _bullets.Count;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Fill()
        {
            for (int i = 0; i < MaxBulletCount; i++)
            {
                _bullets.Add(CreateBullet());
            }
        }

        public IBullet GetBullet()
        {
            IBullet iBullet = GetBulletFromClip();
            TryDestroyClip();

            return iBullet;
        }

        private GameObject CreateBullet() => _gameFactory.CreateGunBullet();

        private IBullet GetBulletFromClip()
        {
            IBullet iBullet = _bullets[0].GetComponent<IBullet>();
            _bullets.Remove(_bullets[0]);

            return iBullet;
        }

        private void TryDestroyClip()
        {
            if (CurrentBulletCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}