using System;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerHealth : MonoBehaviour
    {
        private float _startHealth = 100;
        private float _currentHealth;

        public Action<float, float> OnHealthChanged;

        public float StartHealth => _startHealth;

        public float CurrentHealth => _currentHealth;

        private void Awake()
        {
            ResetHealth();
        }

        public void AddHealth(float heal)
        {
            _currentHealth += heal;
            InvokeOnHealthChanged();
        }

        public void RemoveHealth(float damage)
        {
            _currentHealth -= damage;
            InvokeOnHealthChanged();
        }

        private void ResetHealth()
        {
            _currentHealth = StartHealth;
            InvokeOnHealthChanged();
        }

        private void InvokeOnHealthChanged() => OnHealthChanged?.Invoke(_currentHealth, StartHealth);
    }
}