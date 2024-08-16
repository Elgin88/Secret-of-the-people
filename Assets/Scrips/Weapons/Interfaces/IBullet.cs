using Scripts.CodeBase.Logic;

namespace Scripts.Weapons
{
    public interface IBullet
    {
        public float StartSpeed { get; }

        public void Move();

        public void Construct(IGameFactory iGameFactory);
    }
}