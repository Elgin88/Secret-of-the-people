using Scripts.CodeBase.Logic;

namespace Scripts.Weapons
{
    public interface IClip
    {
        public string Name { get; }

        public void Fill();

        public void Construct(IGameFactory iGameFactory);

        public void RemoveTopBullet();

        public int GetBulletCurrentCount();

        public IBullet GetTopBullet();
    }
}