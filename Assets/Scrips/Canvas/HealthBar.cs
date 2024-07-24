using Scripts.PlayerComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Canvas
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        private PlayerHealth _playerHealth;

        public void Construct(PlayerHealth playerHealth) => _playerHealth = playerHealth;

        private void Start()
        {
            ResetBarValues();
            ResetBarSlider();
            SubscribeOnHealthChanged();

            Debug.Log("Отключить перемещение игрока при падении");
        }

        private void OnDestroy() => UnsubscribeOnHealthChanged();

        private void OnHealthChanged(float current, float max)
        {
            SetSlider(current, max);
            SetValues(current, max);
        }

        private void SubscribeOnHealthChanged() => _playerHealth.OnHealthChanged += OnHealthChanged;

        private void UnsubscribeOnHealthChanged() => _playerHealth.OnHealthChanged -= OnHealthChanged;

        private void ResetBarSlider() => _slider.value = 1;

        private void ResetBarValues() => _text.text = _playerHealth.StartHealth + "/" + _playerHealth.StartHealth;

        private void SetSlider(float current, float max) => _slider.value = current / max;

        private void SetValues(float current, float max) => _text.text = current + "/" + max;
    }
}
