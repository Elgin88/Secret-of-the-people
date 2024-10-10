using System.Runtime.CompilerServices;
using Secret.StaticData;
using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IWeapon, IGun, IWeaponAttacker
    {
        [SerializeField] private WeaponStaticData _staticData;

        private float _maxCooldown => _staticData.DelayBetweenShoots;
        private float _currentCooldown;
        private IWeaponContainer _iWeaponContainer;
        private IWeaponReloader _iWeaponReloader;

        private void Awake()
        {
            _iWeaponContainer = GetComponent<IWeaponContainer>();
            _iWeaponReloader = GetComponent<IWeaponReloader>();
        }

        public void Attack()
        {
            UpdateCooldown();
            
            TryReload();

            if (CooldownIsEnd())
            {
                StartBulletMovement();
                ResetCooldown();
            }
        }

        private bool CooldownIsEnd() => _currentCooldown <=0;
        private void UpdateCooldown() => _currentCooldown -= Time.deltaTime;
        private void ResetCooldown() => _currentCooldown = _maxCooldown;
        private void StartBulletMovement() => _iWeaponContainer.IBulletMover?.StartMove();
        private void TryReload()
        {
            if (_iWeaponContainer.ICurrentClip == null)
            {
                _iWeaponReloader.Reload();

                return;
            }
            
            if (_iWeaponContainer.ICurrentClip.CurrentBulletCount <= 0)
            {
                _iWeaponReloader.Reload();
            }
        }
    }
}