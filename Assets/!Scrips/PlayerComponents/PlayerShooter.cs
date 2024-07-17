using System.Collections.Generic;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private List<Weapon> _weapon;

        public Transform ShootPoint => _shootPoint;

        private void FixedUpdate()
        {
        }

        public void Shoot(Weapon weapon) => weapon.Shoot();
    }
}