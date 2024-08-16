using Scripts.Interfaces;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Enemy
{
    public class HealthSetter : MonoBehaviour, IHealth
    {
        [SerializeField] private EnemyStaticData _staticData;

        private int _startHealth;
        private int _currentHealth;

        public int StartHealth => _startHealth;

        public int CurrentHealth => _currentHealth;

        private void Awake()
        {
            SetStartHealth(GetStartHealth());
            SetCurrentHealth(_startHealth);
        }

        public void Heal(int heal)
        {
            _currentHealth += heal;

            if (_staticData.StartHealth < _currentHealth)
            {
                SetCurrentHealth(_startHealth);
            }
        }

        public void SetCurrentHealth(int health) => _currentHealth = health;

        public void SetStartHealth(int health) => _startHealth = health;

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }
        }

        private int GetStartHealth() => _staticData.StartHealth;
    }
}