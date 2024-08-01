using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;
        [SerializeField] private Transform _shootPoint;

        public Transform ShootPoint => _shootPoint;

        private void Attack()
        {
            _playerChooserWeapon.CurrentWeapon.Shoot();
        }
    }
}