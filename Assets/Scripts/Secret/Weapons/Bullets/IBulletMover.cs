namespace Secret.Weapons.Bullets
{
    public interface IBulletMover : IBullet
    {
        public float MoveSpeed { get; }

        public void StartMove();

        public void StopMove();
    }
}