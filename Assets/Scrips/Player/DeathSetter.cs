using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(AnimationsSetter))]
    [RequireComponent(typeof(HealthSetter))]

    public class DeathSetter : MonoBehaviour
    {
        [SerializeField] private AnimationsSetter _animationsSetter;
        [SerializeField] private HealthSetter _healthSetter;

        private void Awake() => _healthSetter.OnHealthChanged += OnPlayerChanged;

        private void OnDestroy() => _healthSetter.OnHealthChanged -= OnPlayerChanged;

        private void OnPlayerChanged(float current, float max)
        {
            if (current <= 0)
            {
                _animationsSetter.PlayDead();
            }
        }
    }
}