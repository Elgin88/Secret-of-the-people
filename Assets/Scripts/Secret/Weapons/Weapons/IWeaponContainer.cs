namespace Secret.Weapons
{
    public interface IWeaponContainer
    {
        public void AddClipFromInventory();

        public IClip ICurrentClip { get; }

        public IBulletMover GetTopIBulletMover();
    }
}