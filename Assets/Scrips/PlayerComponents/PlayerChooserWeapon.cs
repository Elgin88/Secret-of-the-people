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
            SetCurrentWeapon(_playerInventory.GetWeaponGun().GetComponent<IWeapon>());
        }

        private void SetCurrentWeapon(IWeapon iWeapon) => _iCurrentWeapon = iWeapon;
    }
}