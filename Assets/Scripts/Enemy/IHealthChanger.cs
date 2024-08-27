namespace Enemy
{
    public interface IHealthChanger
    {
        public int StartHealth { get; }
        
        public int CurrentHealth { get; }

        public void AddHealth(int heal);

        public void RemoveHealth(int damage);
    }
}