using Secret.Infrastructure.Factory;
using Secret.Player.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Secret.Canvas
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        private HealthChanger _healthChanger;
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void Start()
        {
            SetPlayerHealth();
            ResetBarValues();
            ResetBarSlider();
            SubHealthChanged();
        }

        private void OnDestroy() => UnsubHealthChanged();

        private void OnHealthChanged(int current, int max)
        {
            SetSlider(current, max);
            SetValues(current, max);
        }

        private void SetPlayerHealth() => _healthChanger = _gameFactory.Player.GetComponent<HealthChanger>();

        private void SubHealthChanged() => _healthChanger.HealthChanged += OnHealthChanged;

        private void UnsubHealthChanged() => _healthChanger.HealthChanged -= OnHealthChanged;

        private void ResetBarSlider() => _slider.value = 1;

        private void ResetBarValues() => _text.text = _healthChanger.CurrentHealth + "/" + _healthChanger.CurrentHealth;

        private void SetSlider(float current, float max) => _slider.value = current / max;

        private void SetValues(float current, float max) => _text.text = current + "/" + max;
    }
}
