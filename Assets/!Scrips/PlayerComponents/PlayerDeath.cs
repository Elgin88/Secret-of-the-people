using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private PlayerHealth _playerHealth;

        private void Awake() => _playerHealth.OnHealthChanged += OnPlayerChanged;

        private void OnDestroy() => _playerHealth.OnHealthChanged -= OnPlayerChanged;

        private void OnPlayerChanged(float current, float max)
        {
            if (current <= 0)
            {
                _playerAnimator.PlayDead();
            }
        }
    }
}