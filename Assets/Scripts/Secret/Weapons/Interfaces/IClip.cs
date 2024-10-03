namespace Secret.Weapons.Interfaces
{
    public interface IClip
    {
        public int MaxBulletCount { get; }

        public int CurrentBulletCount { get; }

        public IBullet GetBullet();

        public void Fill();
    }
}