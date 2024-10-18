namespace Secret.Weapons.Clips
{
    public interface IClipContainer
    {
        public int BulletCount { get; }

        public void Fill();
    }
}