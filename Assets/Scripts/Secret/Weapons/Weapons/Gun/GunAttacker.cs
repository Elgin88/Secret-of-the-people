using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IWeapon, IGun, IWeaponAttacker
    {
        private IWeaponContainer _iWeaponContainer;

        private void Awake()
        {
            _iWeaponContainer = GetComponent<IWeaponContainer>();
        }

        public void Attack()
        {
            if (_iWeaponContainer.ICurrentClip == null)
            {
                Debug.Log("Нет обоймы");
            }
            _iWeaponContainer.ICurrentClip?.ICurrentBullet?.ICurrentBulletMover?.StartMove();
        }
    }
}