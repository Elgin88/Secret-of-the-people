namespace Scripts.Weapons
{
    public interface IBullet
    {
        public float Speed { get; }

        public void Shoot();
    }
}