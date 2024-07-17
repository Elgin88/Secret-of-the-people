using System.Collections;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : Weapon
    {
        [SerializeField] private float _intervalBetweenBullets;
        [SerializeField] private float _durationReload;
        [SerializeField] private int _numberBulletsInClip;
        [SerializeField] private GameObject _gunBullet;

        private WaitForSeconds _interval;
        private Transform _shootPoint;
        private bool _isIntervalEnd;

        public override float IntervelBetweenBullets => _intervalBetweenBullets;

        public override float DurationReload => _durationReload;

        public override int NumberBulletsInClip => _numberBulletsInClip;

        private void Awake()
        {
            SetInterval();
            SetIsIntervalEndTrue();
        }

        public override void Shoot()
        {
            if (_isIntervalEnd)
            {
                CreateBullet();
                SetIsIntervalEndFalse();
                SetIsIntervalEndTrueAfterInterval();
            }
        }

        public override void Reload()
        {
        }

        private IEnumerator CalculateInterval()
        {
            yield return _interval;
            _isIntervalEnd = true;
        }

        private void CreateBullet() => Instantiate(_gunBullet, _shootPoint.position, Quaternion.identity);
        private void SetInterval() => _interval = new WaitForSeconds(_intervalBetweenBullets);
        private void SetIsIntervalEndTrue() => _isIntervalEnd = true;
        private void SetIsIntervalEndFalse() => _isIntervalEnd = false;
        private void SetIsIntervalEndTrueAfterInterval() => StartCoroutine(CalculateInterval());
    }
}