using UnityEngine;

namespace Secret.Player.Inventory
{
    public class StartWeaponSetter : MonoBehaviour
    {
        private IChooserWeapon _chooserWeapon;
        private IContainer _container;

        private void Awake()
        {
            _chooserWeapon = GetComponent<IChooserWeapon>();
            _container = GetComponent<IContainer>();
        }

        public void Construct()
        {
            SetGunStartWeapon();
        }

        private void SetGunStartWeapon() => _chooserWeapon.SetCurrentWeapon(_container.GetGun());
    }
}