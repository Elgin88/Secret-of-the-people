using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.Weapons
{
    [RequireComponent(typeof(GunReloader))]
    [RequireComponent(typeof(GunShooter))]
    [RequireComponent(typeof(GunClipSetter))]

    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GunShooter _gunShooter;
        [SerializeField] private GunReloader _gunReloader;

        private IGameFactory _iGameFactory;
        private IClip _iClip;

        public IGameFactory IGameFactory => _iGameFactory;

        public IClip IClip => _iClip;

        public void Construct(IGameFactory iGameFactory)
        {
            SetGameFactory(iGameFactory);
        }

        public void Shoot()
        {
            _gunShooter.Shoot();
        }

        public void Reload()
        {
        }

        private void SetGameFactory(IGameFactory gameFactory) => _iGameFactory = gameFactory;
    }
}