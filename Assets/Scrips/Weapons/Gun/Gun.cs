using System.Collections;
using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponStaticData _staticData;

        private IGameFactory _iGameFactory;
        private float _delayBetweenShoots;
        private float _durationReload;
        private float _currentColldawn = 0;
        private bool _isCanShoot = true;
        private int _countBulletsInClip;

        public float DelayBetweenShoots => _delayBetweenShoots;

        public float DurationReload => _durationReload;

        public int CountBulletsInClip => _countBulletsInClip;

        public bool IsCanShoot => _isCanShoot;

        private void Start()
        {
            SetParametrs();

            Debug.Log(_iGameFactory);
            Debug.Log(_iGameFactory.GunBullet);
        }

        public void Construct(IGameFactory iGameFactory)
        {
            SetGameFactory(iGameFactory);
        }

        public void FixedUpdate()
        {
            UpdateColldawn();
        }

        public void Shoot()
        {
            if (IsCooldawnOut())
            {
                ResetCooldawn();

                Debug.Log("Shoot");

                CreateBullet();
                RemoveBulltetFromClip();
            }
        }

        public void Reload()
        {
        }

        private void RemoveBulltetFromClip()
        {
        }

        private IEnumerator CalculateDelay()
        {
            yield return GetDelay();

            SetIsCanShoot();
        }

        private void CreateBullet()
        {
            Instantiate(SetBullet(), SetBulletPosition(), SetBulletRotation());
            ResetIsCanShoot();
            StartCalculateDelay();
        }

        private void SetGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void SetIsCanShoot() => _isCanShoot = true;

        private void ResetIsCanShoot() => _isCanShoot = false;

        private void StartCalculateDelay() => StartCoroutine(CalculateDelay());

        private bool IsCooldawnOut() => _currentColldawn < 0;

        private void ResetCooldawn() => _currentColldawn = _delayBetweenShoots;

        private void UpdateColldawn() => _currentColldawn -= Time.deltaTime;

        private static Quaternion SetBulletRotation() => Quaternion.identity;

        private Vector3 SetBulletPosition() => _iGameFactory.Player.GetComponentInChildren<PlayerShootPoint>().transform.position;

        private GameObject SetBullet() => _iGameFactory.GunBullet;

        private WaitForSeconds GetDelay() => new WaitForSeconds(_delayBetweenShoots);

        private void SetParametrs()
        {
            _delayBetweenShoots = _staticData.DelayBetweenShoots;
            _durationReload = _staticData.DurationReload;
            _countBulletsInClip = _staticData.CountBulletsInClip;
        }
    }
}