using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunReloader : MonoBehaviour, IGun, IWeaponReloader
    {
        private IWeaponContainer _weaponContainer;

        private void Awake()
        {
            _weaponContainer = GetComponent<IWeaponContainer>();
        }

        private void FixedUpdate()
        {
            if (NoClipInWeapon())
            {
                Reload();
            }
        }

        private void Reload() => _weaponContainer.SetCurrentClip();

        private bool NoClipInWeapon() => _weaponContainer.CurrentClip == null;
    }
}