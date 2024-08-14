using Scripts.CodeBase.Logic;

namespace Scripts.Weapons
{
    public interface IBullet
    {
        public float Speed { get; }

        public void Fly();

        public void SetStartPosition();

        public void Construct(IGameFactory iGameFactory);
    }
}