namespace Secret.Weapons
{
    public interface IWeaponContainer
    {
        public IBulletMover IBulletMover { get; }

        public void AddClipFromInventory();
    }
}