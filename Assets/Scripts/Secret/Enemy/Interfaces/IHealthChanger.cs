namespace Secret.Enemy.Interfaces
{
    public interface IEnemyHealthChanger
    {
        public void AddHealth(int heal);

        public void RemoveHealth(int damage);
    }
}