using UnityEngine;

namespace Scripts.Player
{
    public class DeathSetter : MonoBehaviour
    {
        [SerializeField] private AnimationsSetter _animationsSetter;
        [SerializeField] private HealthChanger _healthSetter;

        private void Awake() => _healthSetter.HealthChanged += OnHealthChanged;

        private void OnDestroy() => _healthSetter.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(int current, int max)
        {
            if (current <= 0)
            {
                _animationsSetter.PlayDead();
            }
        }
    }
}