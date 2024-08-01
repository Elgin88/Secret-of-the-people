using System.Collections;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : Weapon
    {
        [SerializeField] private WeaponStaticData _staticData;
        [SerializeField] private Bullet _bullet;

        private Transform _shootPoint;
        private float _delayBetweenShoots;
        private float _durationReload;
        private bool _isCanShoot = true;
        private int _countBulletsInClip;

        public override float DelayBetweenShoots => _delayBetweenShoots;

        public override float DurationReload => _durationReload;

        public override int CountBulletsInClip => _countBulletsInClip;

        public override bool IsCanShoot => _isCanShoot;

        public override void Construct()
        {
            _delayBetweenShoots = _staticData.DelayBetweenShoots;
            _durationReload = _staticData.DurationReload;
            _countBulletsInClip = _staticData.CountBulletsInClip;
        }

        public override void Shoot()
        {
            if (_isCanShoot)
            {
                CreateBullet();
            }
        }

        public override void Reload()
        {
        }

        private IEnumerator CalculateDelay()
        {
            yield return new WaitForSeconds(_delayBetweenShoots);
            SetIsCanShoot();
        }

        private void CreateBullet()
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            ResetIsCanShoot();
            StartCalculateDelay();
        }

        private void SetIsCanShoot()
        {
            _isCanShoot = true;

            Debug.Log(_isCanShoot);
        }

        private void ResetIsCanShoot() => _isCanShoot = false;

        private void StartCalculateDelay() => StartCoroutine(CalculateDelay());
    }
}