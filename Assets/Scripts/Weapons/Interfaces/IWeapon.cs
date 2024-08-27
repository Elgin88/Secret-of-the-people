namespace Weapons.Interfaces
{
    public interface IWeapon
    {
        public string Name { get; }

        public IClip CurrentClip { get; }

        public void Shoot();

        public void Reload();

        public void SetCurrentClip(IClip clip);
    }
}