using Secret.Weapons.Bullets;

namespace Secret.Weapons.Clips
{
    public interface IClipContainer
    {
        public IBullet ICurrentBullet { get; }

        public void SetICurrentBullet();
    }
}