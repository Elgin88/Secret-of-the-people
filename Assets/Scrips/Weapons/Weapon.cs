using UnityEngine;

namespace Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract float DelayBetweenShoots { get; }

        public abstract float DurationReload { get; }

        public abstract int CountBulletsInClip { get; }

        public abstract bool IsCanShoot { get; }

        public abstract void Shoot();

        public abstract void Reload();
    }
}