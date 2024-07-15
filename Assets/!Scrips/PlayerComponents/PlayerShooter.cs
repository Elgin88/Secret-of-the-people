using Scripts.Bullets;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerShooter : MonoBehaviour
    {
        private Bullet _bullet;

        public void Shoot(Weapon weapon)
        {
            weapon.Shoot(_bullet);
        }
    }
}