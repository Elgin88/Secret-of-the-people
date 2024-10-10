using Secret.Weapons.Bullets;
using Secret.Weapons.Clips;

namespace Secret.Weapons.Weapons
{
    public interface IWeaponContainer
    {
        public IClip ICurrentClip { get; set; }
        public IBulletMover IBulletMover { get; set; }

        public void AddClipFromInventory();
    }
}