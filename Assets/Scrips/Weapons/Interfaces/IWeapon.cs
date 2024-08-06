namespace Scripts.Weapons
{
    public interface IWeapon
    {
        public float DelayBetweenShoots { get; }

        public float DurationReload { get; }

        public void TryShoot();

        public void Reload();
    }
}