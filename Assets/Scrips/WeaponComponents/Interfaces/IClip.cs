using Scripts.CodeBase.Logic;

namespace Scripts.WeaponsComponents
{
    public interface IClip
    {
        public string Name { get; }

        public void Fill();

        public void Construct(IGameFactory iGameFactory);

        public void RemoveTopBullet();

        public IBullet GetTopBullet();
    }
}