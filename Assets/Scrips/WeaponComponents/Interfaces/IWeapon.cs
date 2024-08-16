using Scripts.CodeBase.Logic;

namespace Scripts.Weapons
{
    public interface IWeapon
    {
        public string Name { get; }

        public IClip CurrentClip { get; }

        public void Shoot();

        public void Reload();

        public void SetcCurrentClip(IClip clip);

        public void Construct(IGameFactory iGameFactory);
    }
}