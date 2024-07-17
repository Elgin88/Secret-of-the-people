using UnityEngine;

namespace Scripts.Bullets
{
    public class GunBullet : Bullet
    {
        [SerializeField] private float _speed;

        public override float Speed => _speed;
    }
}