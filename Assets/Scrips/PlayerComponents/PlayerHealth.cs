using Scripts.StaticData;
using System;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _staticData;

        private float _currentHealth;
        private float _health;
        private bool _isDead = false;

        public Action<float, float> OnHealthChanged;

        public float Health => _health;

        public float CurrentHealth => _currentHealth;

        public bool IsDead => _isDead;

        private void Awake()
        {
            SetStartHealth();
            ResetHealth();
        }

        public void AddHealth(float heal)
        {
            _currentHealth += heal;

            InvokeOnHealthChanged();
            SetStatusIsDead();
        }

        public void RemoveHealth(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }

            InvokeOnHealthChanged();
            SetStatusIsDead();
        }

        private void InvokeOnHealthChanged() => OnHealthChanged?.Invoke(_currentHealth, Health);

        private void SetStartHealth() => _health = _staticData.Health;

        private void ResetHealth()
        {
            _currentHealth = Health;
            InvokeOnHealthChanged();
        }

        private void SetStatusIsDead()
        {
            if (_currentHealth > 0)
            {
                _isDead = false;
            }
            else
            {
                _isDead = true;
            }
        }
    }
}