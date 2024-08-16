namespace Scripts.Interfaces
{
    public interface IHealth
    {
        public int StartHealth { get; }

        public int CurrentHealth { get; }

        public void Heal(int heal);

        public void TakeDamage(int damage);

        public void SetCurrentHealth(int currentHeath);

        public void SetStartHealth(int health);
    }
}