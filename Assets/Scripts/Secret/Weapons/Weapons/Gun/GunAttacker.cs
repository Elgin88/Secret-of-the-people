using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IGun, IWeaponAttacker, IWeapon
    {
        private IWeaponContainer _weaponContainer;
        private IWeaponAttacker _weaponAttacker;

        public IWeaponAttacker WeaponAttacker => _weaponAttacker;

        private void Awake()
        {
            _weaponContainer = GetComponent<IWeaponContainer>();
            _weaponAttacker = GetComponent<IWeaponAttacker>();
        }

        public void Attack()
        {
            if (_weaponContainer.CurrentClip == null)
            {
                Debug.Log("Нет обоймы");

                return;
            }

            Debug.Log("Attack");
        }
    }
}