using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunClip : MonoBehaviour, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private int _maxBulletCount;
        private int _currentBulletCount;

        public int CountBulletsInClip => _maxBulletCount;

        private void Start()
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