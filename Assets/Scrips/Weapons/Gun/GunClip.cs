using Scripts.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunClip : MonoBehaviour, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private List<GameObject> _bullets;
        private int _maxBulletCount;
        private int _currentBulletCount;

        public int CountBulletsInClip => _maxBulletCount;

        private void Awake()
        {
            SetMaxBulletCount();
        }

        public void Reload()
        {
            _currentBulletCount = _maxBulletCount;
        }

        public void RemoveBullet()
        {
        }

        private void SetMaxBulletCount() => _maxBulletCount = _staticData.CountBulletsInClip;
    }
}