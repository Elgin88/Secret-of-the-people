namespace Weapons.Interfaces
{
    public interface IClip
    {
        public string Name { get; }

        public void Fill();

        public void RemoveTopBullet();

        public int GetBulletCurrentCount();

        public IBullet GetTopBullet();
    }
}