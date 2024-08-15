using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using Scripts.PlayerComponents.InventoryComponents;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunComponents
{
    [RequireComponent(typeof(GunClip))]
    [RequireComponent(typeof(Reloader))]

    public class Shooter : MonoBehaviour
    {
        [SerializeField] private WeaponStaticData _staticData;
        [SerializeField] private ClipSetter _clipSetter;
        [SerializeField] private Reloader _reloader;

        private NextTargetFinder _nextTargetFinder;
        private IGameFactory _gameFactory;
        private float _cooldawn;
        private float _delay;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
            SetNextTargetFinder();
        }

        private void Awake()
        {
            SetDelay();
        }

        private void FixedUpdate()
        {
            UpdateCooldawn();
        }

        public void Shoot()
        {
            if (IsCooldawnEnd() & IsNotReloading() & TargetIsFind())
            {
                FlyBullet();
                ResetColldawn();
            }

            if (BulletCount() == 0)
            {
                Reload();
            }
        }

        private bool TargetIsFind() => _nextTargetFinder.CurrentTarget != null;

        private bool IsNotReloading() => _reloader.IsReloading == false;

        private void Reload() => _reloader.Reload();

        private void UpdateCooldawn() => _cooldawn -= Time.deltaTime;

        private void SetDelay() => _delay = _staticData.DelayBetweenShoots;

        private void ResetColldawn() => _cooldawn = _delay;

        private bool IsCooldawnEnd() => _cooldawn <= 0;

        private IClip GetCurrentClip(IGameFactory gameFactory) => gameFactory.Player.GetComponent<ChooserWeapon>().CurrentWeapon.IClip;

        private void SetGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private int BulletCount() => GetCurrentClip(_gameFactory).GetBulletCurrentCount();

        private void SetNextTargetFinder() => _nextTargetFinder = _gameFactory.Player.GetComponent<NextTargetFinder>();

        private void FlyBullet()
        {
            _clipSetter.CurrentClip.GetTopBullet().Move();
            _clipSetter.CurrentClip.RemoveTopBullet();
        }
    }
}