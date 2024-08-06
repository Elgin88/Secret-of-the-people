namespace Scripts.Weapons
{
    public interface IClip
    {
        public int CountBulletsInClip { get; }

        public void RemoveBullet();

        public void Reload();
    }
}