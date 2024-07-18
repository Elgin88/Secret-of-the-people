using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;

        public Transform ShootPoint => _shootPoint;

        private void FixedUpdate() => Shoot();

        private void Shoot() => _playerChooserWeapon.CurrentWeapon.Shoot();
    }
}