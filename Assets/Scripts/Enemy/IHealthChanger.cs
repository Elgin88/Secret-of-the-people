namespace Enemy
{
    public interface IHealthChanger
    {
        public int StartHealth { get; }
        
        public int CurrentHealth { get; }

        public void AddCurrentHealth(int heal);

        public void RemoveCurrentHealth(int damage);
    }
}