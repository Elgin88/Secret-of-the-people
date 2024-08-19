using UnityEngine;

namespace Scripts.Player
{
    public class DeathSetter : MonoBehaviour
    {
        [SerializeField] private AnimationSetter _animationsSetter;
        [SerializeField] private HealthChanger _healthChanger;

        private Coroutine _playAnimation;

        private void Awake()
        {
            _healthChanger.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _healthChanger.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int current, int max)
        {
            if (current <= 0)
            {
                _animationsSetter.PlayDeadAnimation();
            }
        }
    }
}