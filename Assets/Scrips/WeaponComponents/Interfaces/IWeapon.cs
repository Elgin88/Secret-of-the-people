using Scripts.CodeBase.Logic;

namespace Scripts.Weapons
{
    public interface IWeapon
    {
        public IGameFactory IGameFactory { get; }

        public IClip IClip { get; }

        public void Shoot();

        public void Reload();

        public void Construct(IGameFactory iGameFactory);
    }
}