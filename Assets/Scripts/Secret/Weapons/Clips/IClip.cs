using Secret.Weapons.Bullets;

namespace Secret.Weapons.Clips
{
    public interface IClip
    {
        public IBullet ICurrentBullet { get; }

        public IBulletMover ICurrentBulletMover { get; }

        public int CurrentBulletCount { get; }
    }
}