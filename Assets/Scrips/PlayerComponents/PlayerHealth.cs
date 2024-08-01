using System;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _staticData;

        private float _startHealth;
        private float _currentHealth;
        private bool _isDead = false;

        public Action<float, float> OnHealthChanged;

        public bool IsDead => _isDead;

        public float StartHealth => _startHealth;

        public float CurrentHealth => _currentHealth;

        private void Awake()
        {
            SetStartHealth();
            ResetHealth();
        }

        public void AddHealth(float heal)
        {
            _currentHealth += heal;
            InvokeOnHealthChanged();

            if (_currentHealth > 0)
            {
                _isDead = false;
            }
        }

        public void RemoveHealth(float damage)
        {
            _currentHealth -= damage;

            InvokeOnHealthChanged();

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                _isDead = true;
            }
        }

        private void ResetHealth()
        {
            _currentHealth = StartHealth;
            InvokeOnHealthChanged();
        }

        private void InvokeOnHealthChanged() => OnHealthChanged?.Invoke(_currentHealth, StartHealth);

        private void SetStartHealth() => _startHealth = _staticData.Health;
    }
}