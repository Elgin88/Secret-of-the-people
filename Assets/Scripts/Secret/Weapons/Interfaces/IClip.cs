namespace Secret.Weapons.Interfaces
{
    public interface IClip
    {
        public int BulletCount { get; }

        public void Fill();
    }
}