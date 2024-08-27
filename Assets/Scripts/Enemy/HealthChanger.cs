using System;
using StaticData;
using UnityEngine;

namespace Enemy
{
    public class HealthChanger : MonoBehaviour, IHealthChanger
    {
        [SerializeField] private EnemyStaticData _staticData;

        private int _maxHealth;
        private int _currentHealth;

        public int StartHealth => _maxHealth;

        public int CurrentHealth => _currentHealth;

        public Action<int, int> OnHealthChanged;

        private void Awake()
        {
            SetMaxHealth(_staticData.MaxHealth);
            SetCurrentHealth(_maxHealth);
        }

        public void AddCurrentHealth(int heal)
        {
            _currentHealth += heal;

            if (_staticData.MaxHealth < _currentHealth)
            {
                SetCurrentHealth(_maxHealth);
            }

            InvokeHealthChanged();
        }

        public void RemoveCurrentHealth(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }

            InvokeHealthChanged();
        }

        private void SetMaxHealth(int health)
        {
            _maxHealth = health;
            InvokeHealthChanged();
        }

        private void SetCurrentHealth(int health)
        {
            _currentHealth = health;
            InvokeHealthChanged();
        }

        public void InvokeHealthChanged() => OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}