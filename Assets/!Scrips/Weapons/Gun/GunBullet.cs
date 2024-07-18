using UnityEngine;

namespace Scripts.Weapons
{
    public class GunBullet : Bullet
    {
        [SerializeField] private float _speed;

        public override float Speed => _speed;
    }
}