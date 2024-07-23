using System.Collections;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : Weapon
    {
        [SerializeField] private float _delayBetweenShoots = 1;
        [SerializeField] private float _durationReload = 2;
        [SerializeField] private int _countBulletsInClip = 8;
        [SerializeField] private Bullet _bullet;

        private WaitForSeconds _delay;
        private Transform _shootPoint;
        private bool _isEndDelayBetweenShoots;

        public override float DurationReload => _durationReload;

        public override float DelayBetweenShoots => _delayBetweenShoots;

        public override int CountBulletsInClip => _countBulletsInClip;

        private void Awake()
        {
            SetDelayBetweenShots();
            ResetDelay();
        }

        public override void Shoot()
        {
            if (_isEndDelayBetweenShoots)
            {
                CreateBullet();
            }
        }

        public override void Reload()
        {
        }

        private void StartColldawn() => StartCoroutine(CalculateInterval());

        private IEnumerator CalculateInterval()
        {
            yield return _delay;
            ResetDelay();
        }

        private void CreateBullet()
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            StartDelay();
            StartColldawn();
        }

        private void SetDelayBetweenShots() => _delay = new WaitForSeconds(_delayBetweenShoots);

        private void ResetDelay() => _isEndDelayBetweenShoots = true;

        private void StartDelay() => _isEndDelayBetweenShoots = false;
    }
}