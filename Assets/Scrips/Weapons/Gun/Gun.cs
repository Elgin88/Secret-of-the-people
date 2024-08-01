using System.Collections;
using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : Weapon
    {
        private Transform _shootPoint;
        private float _delayBetweenShoots;
        private float _durationReload;
        private bool _isCanShoot = true;
        private int _countBulletsInClip;
        private IGameFactory _iGameFactory;

        public override float DelayBetweenShoots => _delayBetweenShoots;

        public override float DurationReload => _durationReload;

        public override int CountBulletsInClip => _countBulletsInClip;

        public override bool IsCanShoot => _isCanShoot;

        public void Construct(IGameFactory gameFactory)
        {
            _iGameFactory = gameFactory;
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
            //Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            ResetIsCanShoot();
            StartCalculateDelay();
        }

        private void SetIsCanShoot() => _isCanShoot = true;

        private void ResetIsCanShoot() => _isCanShoot = false;

        private void StartCalculateDelay() => StartCoroutine(CalculateDelay());
    }
}