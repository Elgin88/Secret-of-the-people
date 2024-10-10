using System;
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
            _iWeaponContainer.GetTopIBulletMover()?.StartMove();

            Debug.Log(_iWeaponContainer.GetTopIBulletMover());
        }

        private void TryReload()
        {
            if (_iWeaponContainer.ICurrentClip == null)
            {
                _iWeaponReloader.Reload();
            }
        }
    }
}