using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(HealthChanger))]
    public class DeathSetter : MonoBehaviour
    {
        [SerializeField] private HealthChanger _healthChanger;

        private Coroutine _playAnimation;

        private void Awake()
        {
            _healthChanger.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            if (_healthChanger is not null) _healthChanger.HealthChanged -= OnHealthChanged;
        }

        private static void OnHealthChanged(int current, int max)
        {
            if (current <= 0)
            {
            }
        }
    }
}