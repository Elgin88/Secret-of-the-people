using UnityEngine;

namespace Scripts.Player
{
    public class DeathSetter : MonoBehaviour
    {
        [SerializeField] private AnimationsSetter _animationsSetter;
        [SerializeField] private HealthChanger _healthChanger;

        private void Awake() => _healthChanger.HealthChanged += OnHealthChanged;

        private void OnDestroy() => _healthChanger.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(int current, int max)
        {
            if (current <= 0)
            {
                _animationsSetter.PlayDeadAnimation();
            }
        }
    }
}