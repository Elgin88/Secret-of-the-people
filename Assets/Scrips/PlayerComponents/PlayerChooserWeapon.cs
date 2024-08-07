using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;

        private IWeapon _iCurrentWeapon;

        public IWeapon ICurrentWeapon => _iCurrentWeapon;

        public void SetCurrentWeapon(IWeapon iWeapon) => _iCurrentWeapon = iWeapon;

        private void Update()
        {
            Debug.Log(_iCurrentWeapon);
        }

    }
}