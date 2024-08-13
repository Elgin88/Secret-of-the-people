using Scripts.CodeBase.Logic;

namespace Scripts.Weapons
{
    public interface IClip
    {
        string Name { get; }

        public void RemoveBullet();

        public void Fill();

        public void Construct(IGameFactory iGameFactory);

        public void RemoveTopBullet();

        public IBullet GetTopBullet();
    }
}