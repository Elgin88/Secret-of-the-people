using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerInventory))]

    public class PlayerInventoryChooserWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;

        private IWeapon _currentWeapon;

        public IWeapon CurrentWeapon => _currentWeapon;

        public void Construct()
        {
            _currentWeapon = _playerInventory.GetGun();
        }
    }
}