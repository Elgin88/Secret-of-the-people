namespace Scripts.Interfaces
{
    public interface IDamage
    {
        public int StartDamage { get; }

        public int CurrentDamage { get; }

        public void SetStartDamage(int startDamage);

        public void SetCurrentDamage(int currentDamage);
    }
}