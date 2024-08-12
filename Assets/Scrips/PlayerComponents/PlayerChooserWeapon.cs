using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;

        private IWeapon _iCurrentWeapon;

        public IWeapon ICurrentWeapon => _iCurrentWeapon;

        private void Start()
        {
            SetICurrentWeapon(GetIGun());
        }

        private IWeapon GetIGun() => _playerInventory.GetIWeaponGun();

        private void SetICurrentWeapon(IWeapon iWeapon) => _iCurrentWeapon = iWeapon;
    }
}