namespace Player.Interfaces
{
    public interface IHealthChanger
    {
        public int StartHealth { get; }

        public int CurrentHealth { get; }

        public void AddCurrentHealth(int heal);

        public void RemoveCurrentHealth(int damage);

        public void SetCurrentHealth(int currentHeath);

        public void SetStartHealth(int startHealth);

        public void InvokeHealthChanged();
    }
}