using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.Weapons
{
    [RequireComponent(typeof(GunReloader))]
    [RequireComponent(typeof(GunShooter))]

    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GunShooter _gunShooter;
        [SerializeField] private GunReloader _gunReloader;

        private IGameFactory _iGameFactory;

        public IGameFactory IGameFactory => _iGameFactory;

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
            _gunReloader.Reload();
        }

        private void SetGameFactory(IGameFactory gameFactory) => _iGameFactory = gameFactory;
    }
}