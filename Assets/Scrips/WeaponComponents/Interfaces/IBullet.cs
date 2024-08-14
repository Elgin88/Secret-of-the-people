using Scripts.CodeBase.Logic;

namespace Scripts.WeaponsComponents
{
    public interface IBullet
    {
        public float StartSpeed { get; }

        public void Fly();

        public void SetStartPosition();

        public void Construct(IGameFactory iGameFactory);
    }
}