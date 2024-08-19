using Scripts.CodeBase.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Canvas
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        private IGameFactory _gameFactory;
        private Player.HealthChanger _playerHealth;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void Start()
        {
            SetPlayerHealth();
            ResetBarValues();
            ResetBarSlider();
            SubscribeOnHealthChanged();
        }

        private void OnDestroy() => UnsubscribeOnHealthChanged();

        private void OnHealthChanged(int current, int max)
        {
            SetSlider(current, max);
            SetValues(current, max);
        }

        private void SetPlayerHealth() => _playerHealth = _gameFactory.Player.GetComponent<Player.HealthChanger>();

        private void SubscribeOnHealthChanged() => _playerHealth.HealthChanged += OnHealthChanged;

        private void UnsubscribeOnHealthChanged() => _playerHealth.HealthChanged -= OnHealthChanged;

        private void ResetBarSlider() => _slider.value = 1;

        private void ResetBarValues() => _text.text = _playerHealth.CurrentHealth + "/" + _playerHealth.CurrentHealth;

        private void SetSlider(float current, float max) => _slider.value = current / max;

        private void SetValues(float current, float max) => _text.text = current + "/" + max;
    }
}
