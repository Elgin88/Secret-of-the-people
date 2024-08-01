namespace Scripts.Weapons
{
    public interface IWeapon
    {
        public float DelayBetweenShoots { get; }

        public float DurationReload { get; }

        public int CountBulletsInClip { get; }

        public bool IsCanShoot { get; }

        public void Shoot();

        public void Reload();
    }
}