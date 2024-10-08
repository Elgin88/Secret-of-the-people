using Secret.Weapons.Gun;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class ChooserWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponContainer _weaponContainer;

        public IWeapon _currentWeapon;

        public void Construct()
        {
            _currentWeapon = _weaponContainer.GetIWeaponGun();
        }
    }
}