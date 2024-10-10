using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunReloader : MonoBehaviour, IWeapon, IGun, IWeaponReloader
    {
        private IWeaponContainer _container;

        private void Awake()
        {
            _container = GetComponent<IWeaponContainer>();
        }

        public void Reload()
        {
            _container.AddClipFromInventory();
        }
    }
}