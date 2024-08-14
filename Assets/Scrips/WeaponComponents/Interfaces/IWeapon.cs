using Scripts.CodeBase.Logic;

namespace Scripts.WeaponsComponents
{
    public interface IWeapon
    {
        public string Name { get; }

        public IClip IClip { get; }

        public void Shoot();

        public void Reload();

        public void SetClip(IClip clip);

        public void Construct(IGameFactory iGameFactory);
    }
}