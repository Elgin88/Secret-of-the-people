using UnityEngine;

namespace Scripts.Player
{
    public class HitTaker : MonoBehaviour
    {
        [SerializeField] private AnimationSetter _animationsSetter;
        [SerializeField] private HealthChanger _healthSetter;

        private void Awake()
        {
            _healthSetter.HealthChanged += OnPlayerHealthChanged;
        }

        private void OnDestroy()
        {
            _healthSetter.HealthChanged -= OnPlayerHealthChanged;
        }

        private void OnPlayerHealthChanged(int current, int start)
        {
            _animationsSetter.PlayHitAnimation();
        }
    }
}