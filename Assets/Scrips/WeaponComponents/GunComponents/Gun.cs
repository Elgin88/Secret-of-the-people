using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunComponents
{
    [RequireComponent(typeof(ClipSetter))]
    [RequireComponent(typeof(Reloader))]
    [RequireComponent(typeof(Shooter))]

    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private ClipSetter _clipSetter;
        [SerializeField] private Reloader _gunReloader;
        [SerializeField] private Shooter _gunShooter;

        private const string _name = StaticWeapon.Gun;

        public string Name => _name;

        public IClip IClip => _clipSetter.CurrentClip;

        public void Construct(IGameFactory gameFactory)
        {
            _clipSetter.Contruct(gameFactory);
            _gunReloader.Construct(gameFactory);
            _gunShooter.Construct(gameFactory);
        }

        public void Shoot()
        {
            _gunShooter.Shoot();
        }

        public void Reload()
        {
            _gunReloader.Reload();
        }

        public void SetClip(IClip clip)
        {
            _clipSetter.SetClip(clip);
        }
    }
}