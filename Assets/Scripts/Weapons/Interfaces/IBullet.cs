namespace Weapons.Interfaces
{
    public interface IBullet
    {
        public float StartSpeed { get; }

        public void Fly();
    }
}