using Infrastructure.Services.Factory;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        private IGameFactory _gameFactory;
        private HealthChanger _healthChanger;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void Start()
        {
            SetPlayerHealth();
            ResetBarValues();
            ResetBarSlider();
            SubOnHealthChanged();
        }

        private void OnDestroy() => UnsubOnHealthChanged();

        private void OnHealthChanged(int current, int max)
        {
            SetSlider(current, max);
            SetValues(current, max);
        }

        private void SetPlayerHealth() => _healthChanger = _gameFactory.Player.GetComponent<Player.HealthChanger>();

        private void SubOnHealthChanged() => _healthChanger.HealthChanged += OnHealthChanged;

        private void UnsubOnHealthChanged() => _healthChanger.HealthChanged -= OnHealthChanged;

        private void ResetBarSlider() => _slider.value = 1;

        private void ResetBarValues() => _text.text = _healthChanger.CurrentHealth + "/" + _healthChanger.CurrentHealth;

        private void SetSlider(float current, float max) => _slider.value = current / max;

        private void SetValues(float current, float max) => _text.text = current + "/" + max;
    }
}
