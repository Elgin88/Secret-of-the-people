using Secret.Weapons;
using Secret.Weapons.Weapons;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class ChooserWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponContainer _weaponContainer;

        public IWeaponAttacker CurrentIWeaponAttacker;

        public void Construct()
        {
            CurrentIWeaponAttacker = _weaponContainer.GetGunIWeaponAttacker();
        }
    }
}