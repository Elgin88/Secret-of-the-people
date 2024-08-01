using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;
        [SerializeField] private Transform _shootPoint;

        public Transform ShootPoint => _shootPoint;

        private void FixedUpdate()
        {
            Attack();

            //Debug.Log("Сделать выстрел, есть уже поиск цели");
        }

        private void Attack()
        {
            _playerChooserWeapon.CurrentWeapon.Shoot();
        }
    }
}