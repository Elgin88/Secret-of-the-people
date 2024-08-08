using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    [RequireComponent(typeof(GunClip))]

    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponStaticData _staticData;
        [SerializeField] private GunClip _gunClip;

        private IGameFactory _iGameFactory;
        private float _delayBetweenShoots;
        private float _durationReload;
        private float _currentColldawn;

        public float DelayBetweenShoots => _delayBetweenShoots;

        public float DurationReload => _durationReload;

        public void Construct(IGameFactory iGameFactory)
        {
            SetGameFactory(iGameFactory);
        }

        private void Start()
        {
            SetParametrs();
        }

        private void FixedUpdate()
        {
            UpdateColldawn();
        }

        public void TryShoot()
        {
            if (IsCooldawnOut())
            {
                ResetCooldawn();
                Shoot();
                RemoveBulletFromClip();
            }
        }

        private void Shoot()
        {
            Debug.Log("Shoot");
        }

        public void Reload()
        {
        }

        private void RemoveBulletFromClip()
        {
        }

        private void SetGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private bool IsCooldawnOut() => _currentColldawn < 0;

        private void ResetCooldawn() => _currentColldawn = _delayBetweenShoots;

        private void UpdateColldawn() => _currentColldawn -= Time.deltaTime;

        private void SetParametrs()
        {
            _delayBetweenShoots = _staticData.DelayBetweenShoots;
            _durationReload = _staticData.DurationReload;
        }
    }
}