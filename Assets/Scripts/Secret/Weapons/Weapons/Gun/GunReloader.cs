using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunReloader : MonoBehaviour, IWeapon, IGun, IWeaponReloader
    {
        private IWeaponContainer _iWeaponContainer;

        private void Awake()
        {
            _iWeaponContainer = GetComponent<IWeaponContainer>();
        }

        private void FixedUpdate()
        {
            //if (NoClips() || NoBulletsInClip())
            //{
            //    Reload();
            //}
        }

        private bool NoClips() => _iWeaponContainer.ICurrentClip == null;

        private bool NoBulletsInClip() => _iWeaponContainer.ICurrentClip?.ICurrentBullet == null;

        private void Reload() => _iWeaponContainer.AddClipFromInventory();
    }
}