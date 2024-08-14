using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Canvas
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        private IGameFactory _gameFactory;
        private HealthSetter _playerHealth;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void Start()
        {
            SetPlayerHealth();
            ResetBarValues();
            ResetBarSlider();
            SubscribeOnHealthChanged();
        }

        private void OnDestroy() => UnsubscribeOnHealthChanged();

        private void OnHealthChanged(float current, float max)
        {
            SetSlider(current, max);
            SetValues(current, max);
        }

        private void SetPlayerHealth() => _playerHealth = _gameFactory.Player.GetComponent<HealthSetter>();

        private void SubscribeOnHealthChanged() => _playerHealth.OnHealthChanged += OnHealthChanged;

        private void UnsubscribeOnHealthChanged() => _playerHealth.OnHealthChanged -= OnHealthChanged;

        private void ResetBarSlider() => _slider.value = 1;

        private void ResetBarValues() => _text.text = _playerHealth.Health + "/" + _playerHealth.Health;

        private void SetSlider(float current, float max) => _slider.value = current / max;

        private void SetValues(float current, float max) => _text.text = current + "/" + max;
    }
}
