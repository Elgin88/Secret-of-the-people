using System;
using StaticData;
using UnityEngine;

namespace Enemy.Logic
{
    public class HealthChanger : MonoBehaviour, IEnemyHealthChanger
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

        public void AddHealth(int heal)
        {
            _currentHealth += heal;

            if (_staticData.MaxHealth < _currentHealth)
            {
                SetCurrentHealth(_maxHealth);
            }

            InvokeHealthChanged();
        }

        public void RemoveHealth(int damage)
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