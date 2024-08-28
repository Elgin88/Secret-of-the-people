namespace Player.Interfaces
{
    public interface IPlayerHealthChanger
    {
        public int StartHealth { get; }

        public int CurrentHealth { get; }

        public void AddHealth(int heal);

        public void RemoveHealth(int damage);

        public void SetCurrentHealth(int currentHeath);

        public void SetStartHealth(int startHealth);
    }
}