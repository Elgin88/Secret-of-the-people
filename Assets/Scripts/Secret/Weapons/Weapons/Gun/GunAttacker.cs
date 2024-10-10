using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IWeapon, IGun, IWeaponAttacker
    {
        private IWeaponContainer _iWeaponContainer;
        private IWeaponReloader _iWeaponReloader;

        private void Awake()
        {
            _iWeaponContainer = GetComponent<IWeaponContainer>();
            _iWeaponReloader = GetComponent<IWeaponReloader>();
        }

        public void Attack()
        {
            TryReload();
            StartBulletMovement();
        }

        private void StartBulletMovement()
        {
            _iWeaponContainer.IBulletMover?.StartMove();
        }

        private void TryReload()
        {
            if (_iWeaponContainer.IBulletMover == null)
            {
                _iWeaponReloader.Reload();
            }
        }
    }
}