using Scripts.Weapons;
using UnityEngine;

namespace Scripts.Player
{
    public class ChooserWeapon : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

        private IWeapon _currentWeapon;

        public IWeapon CurrentWeapon => _currentWeapon;

        public void Construct()
        {
            _currentWeapon = _inventory.GetGun();
        }
    }
}