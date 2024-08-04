using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;

        private GameObject _currentWeapon;

        public GameObject CurrentWeapon => _currentWeapon;

        public IWeapon ICurrentWeapon => _currentWeapon.GetComponent<IWeapon>();

        private void Start() => SetStartWeapon();

        private void SetStartWeapon() => _currentWeapon = _playerInventory.GetStartWeapon();
    }
}