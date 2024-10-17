using Secret.Weapons.Weapons;

namespace Secret.Player.Inventory
{
    public interface IContainer
    {
        public void AddGun();

        public void AddGunClips();

        public IWeapon GetGun();
    }
}