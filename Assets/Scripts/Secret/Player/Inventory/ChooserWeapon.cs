using Secret.Weapons.Weapons;
using Secret.Weapons.Weapons.Gun;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class ChooserWeapon : MonoBehaviour, IChooserWeapon
    {
        private IContainer _container;
        private IWeapon _currentWeapon;

        public IWeapon CurrentWeapon => _currentWeapon;

        private void Awake()
        {
            _container = GetComponent<IContainer>();
        }

        public void SetCurrentWeapon(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }
    }
}