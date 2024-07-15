using Scripts.Bullets;

namespace Scripts.Weapons
{
    public class Gun : Weapon
    {
        public override float IntervelBetweenBullets => throw new System.NotImplementedException();

        public override float DurationReload => throw new System.NotImplementedException();

        public override void Relod()
        {
            throw new System.NotImplementedException();
        }

        public override void Shoot(Bullet bullet)
        {
            throw new System.NotImplementedException();
        }
    }
}