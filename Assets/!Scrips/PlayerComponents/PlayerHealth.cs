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

        public Action<float, float> OnHealthChanged;

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

        private void SetStartHealth() => _startHealth = _staticData.StartHealth;
    }
}