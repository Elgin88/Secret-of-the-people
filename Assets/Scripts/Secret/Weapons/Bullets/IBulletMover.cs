namespace Secret.Weapons.Bullets
{
    public interface IBulletMover
    {
        public float MoveSpeed { get; }

        public void StartMove();

        public void StopMove();
    }
}