using System;
using Scripts.Enemy;
using Scripts.StaticData;
using UnityEngine;

namespace Enemy
{
    public class HealthChanger : MonoBehaviour, IHealthChanger
    {
        [SerializeField] private EnemyStaticData _staticData;

        private int _startHealth;
        private int _currentHealth;

        public int StartHealth => _startHealth;

        public int CurrentHealth => _currentHealth;

        public Action<int, int> OnHealthChanged;
        
        private void Awake()
        {
            SetStartHealth(_staticData.StartHealth);
            SetCurrentHealth(_startHealth);
        }

        public void SetStartHealth(int health)
        {
            _startHealth = health;
            InvokeHealthChanged();
        }

        public void SetCurrentHealth(int health)
        {
            _currentHealth = health;
            InvokeHealthChanged();
        }

        public void AddCurrentHealth(int heal)
        {
            _currentHealth += heal;

            if (_staticData.StartHealth < _currentHealth)
            {
                SetCurrentHealth(_startHealth);
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

        public void InvokeHealthChanged() => OnHealthChanged?.Invoke(_currentHealth, _startHealth);
    }
}