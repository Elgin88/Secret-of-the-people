using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IGun, IWeaponAttacker
    {
        private IWeaponContainer _gunContainer;

        private void Awake()
        {
            _gunContainer = GetComponent<IWeaponContainer>();
        }

        public void Attack()
        {
            if (CantAttack())
            {
                return;
            }

            _gunContainer.BulletMover.CurrentBulletMover.StartMove();
        }

        private bool CantAttack() => _gunContainer.ICurrentClip == null || _gunContainer.ICurrentClip?.ClipContainer?.BulletCount == 0;
    }
}