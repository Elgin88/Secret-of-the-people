using System;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Player
{
    public class HealthChanger : MonoBehaviour, IHealthChanger
    {
        [SerializeField] private PlayerStaticData _staticData;

        private int _startHealth;
        private int _currentHealth;

        public int StartHealth => _startHealth;

        public int CurrentHealth => _currentHealth;

        public Action<int, int> HealthChanged;

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

        public void InvokeHealthChanged() => HealthChanged?.Invoke(_currentHealth, _startHealth);
    }
}