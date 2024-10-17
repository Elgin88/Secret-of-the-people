using Secret.Weapons.Weapons;
using Secret.Weapons.Weapons.Gun;

namespace Secret.Player.Inventory
{
    public interface IChooserWeapon
    {
        public void SetCurrentWeapon(IWeapon weapon);
    }
}