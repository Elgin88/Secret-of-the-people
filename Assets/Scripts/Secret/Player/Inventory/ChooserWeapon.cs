using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class ChooserWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponContainer _weaponContainer;

        private IWeapon _currentWeapon;

        public IWeapon CurrentWeapon => _currentWeapon;

        public void Construct()
        {
            _currentWeapon = _weaponContainer.GetGun();
        }
    }
}