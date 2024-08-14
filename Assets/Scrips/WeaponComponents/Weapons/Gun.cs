using UnityEngine;

namespace Scripts.Weapons
{
    [RequireComponent(typeof(GunClipSetter))]
    [RequireComponent(typeof(GunReloader))]
    [RequireComponent(typeof(GunShooter))]

    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GunClipSetter _clipSetter;
        [SerializeField] private GunReloader _gunReloader;
        [SerializeField] private GunShooter _gunShooter;

        private string _name = StaticWeapon.Gun;

        public string Name => _name;

        public IClip IClip => _clipSetter.CurrentClip;

        public void Shoot()
        {
            _gunShooter.Shoot();
        }

        public void Reload()
        {
        }

        public void SetClip(IClip clip)
        {
            _clipSetter.SetClip(clip);
        }
    }
}