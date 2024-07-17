using UnityEngine;

namespace Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract float IntervelBetweenBullets { get; }
        public abstract float DurationReload { get; }
        public abstract int NumberBulletsInClip { get; }

        public abstract void Shoot();
        public abstract void Reload();
    }
}