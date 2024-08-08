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
        private int _currentBulletCount;

        public int BulletsCount => _maxBulletCount;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
        }

        private void Awake()
        {
            SetMaxBulletCount();
        }

        private void Start()
        {
            AddBulletsInClip();
        }

        public void Reload()
        {
            _currentBulletCount = _maxBulletCount;
        }

        public void RemoveBullet()
        {
        }

        private void SetMaxBulletCount() => _maxBulletCount = _staticData.CountBulletsInClip;

        public void AddBulletsInClip()
        {
            for (int i = 0; i < _maxBulletCount; i++)
            {
                Debug.Log(_bullets);
                Debug.Log(_iGameFactory);

                _bullets.Add(_iGameFactory.CreateGunBullet());
            }
        }

        private void SetIGameFactory(IGameFactory iGameFactory)
        {
            _iGameFactory = iGameFactory;
        }
    }
}