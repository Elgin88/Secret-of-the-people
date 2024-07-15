using Scripts.Bullets;
using UnityEngine;

namespace Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract float IntervelBetweenBullets { get; }
        public abstract float DurationReload { get; }

        public abstract void Shoot(Bullet bullet);
        public abstract void Relod();
    }
}