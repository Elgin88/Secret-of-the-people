namespace Secret.Weapons.Weapons
{
    public interface IWeapon
    {
        public IWeaponAttacker WeaponAttacker { get; }
    }
}