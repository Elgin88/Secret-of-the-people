using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponStaticData _staticData;
        [SerializeField] private GunSetterCurrentClip _gunSetterCurrentClip;

        private IGameFactory _iGameFactory;
        private IClip _currentClip;
        private float _delayBetweenShoots;
        private float _durationReload;
        private float _сolldawn;

        public float DelayBetweenShoots => _delayBetweenShoots;

        public float DurationReload => _durationReload;

        public IGameFactory IGameFactory => _iGameFactory;

        public void Construct(IGameFactory iGameFactory)
        {
            SetGameFactory(iGameFactory);
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
            _gunSetterCurrentClip.CurrentClip.GetComponent<GunClip>().GetTopBullet().Shoot();
        }

        public void Reload()
        {
        }

        private void RemoveBulletFromClip()
        {
        }

        private void SetGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private bool IsCooldawnOut() => _сolldawn < 0;

        private void ResetCooldawn() => _сolldawn = _delayBetweenShoots;

        private void UpdateColldawn() => _сolldawn -= Time.deltaTime;

        private void SetParametrs()
        {
            _delayBetweenShoots = _staticData.DelayBetweenShoots;
            _durationReload = _staticData.DurationReload;
        }
    }
}