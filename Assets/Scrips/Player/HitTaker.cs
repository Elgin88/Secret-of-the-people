using UnityEngine;

namespace Scripts.Player
{
    public class HitTaker : MonoBehaviour
    {
        [SerializeField] private AnimationsSetter _animationsSetter;
        [SerializeField] private HealthSetter _healthSetter;

        private void Awake() => _healthSetter.OnHealthChanged += OnPlayerHealthChanged;

        private void OnDestroy() => _healthSetter.OnHealthChanged -= OnPlayerHealthChanged;

        private void OnPlayerHealthChanged(float current, float start) => Hit();
        private void Hit() => _animationsSetter.PlayHitAnimation();
    }
}