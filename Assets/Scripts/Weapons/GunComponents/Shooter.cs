using Infrastructure.Services.Factory;
using Player;
using Player.Logic;
using StaticData;
using UnityEngine;
using Weapons.Clips;
using Weapons.Interfaces;

namespace Weapons.GunComponents
{
    [RequireComponent(typeof(GunClip))]
    [RequireComponent(typeof(Reloader))]

    public class Shooter : MonoBehaviour
    {
        [SerializeField] private EnemyStaticData _staticData;
        [SerializeField] private ClipSetter _clipSetter;
        [SerializeField] private Reloader _reloader;

        private TargetFinder _nextTargetFinder;
        private IGameFactory _gameFactory;
        private float _cooldown;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
            SetNextTargetFinder();
        }

        public void Shoot()
        {
            if (IsCooldownEnd() & IsNotReloading() & TargetIsFind())
            {
                StartMoveBullet();
            }

            if (BulletCount() == 0)
            {
                Reload();
            }
        }

        private bool TargetIsFind() => _nextTargetFinder.CurrentTarget != null;

        private bool IsNotReloading() => _reloader.IsReloading == false;

        private void Reload() => _reloader.Reload();

        private bool IsCooldownEnd() => _cooldown <= 0;

        private IClip GetCurrentClip(IGameFactory gameFactory) => gameFactory.Player.GetComponent<ChooserWeapon>().CurrentWeapon.CurrentClip;

        private void SetGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private int BulletCount() => GetCurrentClip(_gameFactory).GetBulletCurrentCount();

        private void SetNextTargetFinder() => _nextTargetFinder = _gameFactory.Player.GetComponent<TargetFinder>();

        private void StartMoveBullet()
        {
            _clipSetter.CurrentClip.GetTopBullet().Fly();
            _clipSetter.CurrentClip.RemoveTopBullet();
        }
    }
}