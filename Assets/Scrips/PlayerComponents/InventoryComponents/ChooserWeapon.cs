using Scripts.WeaponsComponents;
using UnityEngine;

namespace Scripts.PlayerComponents.InventoryComponents
{
    [RequireComponent(typeof(Inventory))]

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