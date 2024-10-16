﻿using System;
using Secret.Player.Interfaces;
using Secret.StaticData;
using UnityEngine;

namespace Secret.Player.Logic
{
    public class HealthChanger : MonoBehaviour, IPlayerHealthChanger
    {
        [SerializeField] private PlayerStaticData _staticData;

        public int StartHealth { get; private set; }

        public int CurrentHealth { get; private set; }

        public Action<int, int> HealthChanged;

        private void Awake()
        {
            SetStartHealth(_staticData.StartHealth);
            SetCurrentHealth(StartHealth);
        }

        public void SetStartHealth(int health)
        {
            StartHealth = _staticData.StartHealth;
            InvokeHealthChanged();
        }

        public void SetCurrentHealth(int health)
        {
            CurrentHealth = health;
            InvokeHealthChanged();
        }

        public void AddHealth(int heal)
        {
            CurrentHealth += heal;

            if (_staticData.StartHealth < CurrentHealth)
            {
                SetCurrentHealth(StartHealth);
            }

            InvokeHealthChanged();
        }

        public void RemoveHealth(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }

            InvokeHealthChanged();
        }

        public void InvokeHealthChanged() => HealthChanged?.Invoke(CurrentHealth, StartHealth);
    }
}