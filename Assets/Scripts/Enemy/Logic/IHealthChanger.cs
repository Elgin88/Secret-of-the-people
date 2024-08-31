namespace Enemy.Logic
{
    public interface IEnemyHealthChanger
    {
        public void AddHealth(int heal);

        public void RemoveHealth(int damage);
    }
}