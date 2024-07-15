using System;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerHit : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth.OnHealthChanged += OnPlayerHealthChanged;
        }

        private void OnDestroy()
        {
            _playerHealth.OnHealthChanged -= OnPlayerHealthChanged;
        }

        private void OnPlayerHealthChanged(float current, float start) => Hit();
        private void Hit() => _playerAnimator.PlayHit();
    }
}