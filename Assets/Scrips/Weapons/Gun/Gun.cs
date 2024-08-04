using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using System.Collections;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponStaticData _staticData;

        private Transform _shootPoint;
        private float _delayBetweenShoots;
        private float _durationReload;
        private bool _isCanShoot = true;
        private int _countBulletsInClip;
        private IGameFactory _iGameFactory;

        public float DelayBetweenShoots => _delayBetweenShoots;

        public float DurationReload => _durationReload;

        public int CountBulletsInClip => _countBulletsInClip;

        public bool IsCanShoot => _isCanShoot;

        private void Start()
        {
            _delayBetweenShoots = _staticData.DelayBetweenShoots;
            _durationReload = _staticData.DurationReload;
            _countBulletsInClip = _staticData.CountBulletsInClip;
        }

        public void Construct(IGameFactory gameFactory) => _iGameFactory = gameFactory;

        public void Shoot()
        {
            if (_isCanShoot)
            {
                CreateBullet();
            }
        }

        public void Reload()
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

        private void StartCalculateDelay()
        {
            StartCoroutine(CalculateDelay());
        }
    }
}