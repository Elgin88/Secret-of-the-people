using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;

        private GameObject _currentWeapon;

        private void Start() => SetStartWeapon();

        private void SetStartWeapon() => _currentWeapon = _playerInventory.GetStartWeapon();
    }
}