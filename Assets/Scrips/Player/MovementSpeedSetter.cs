using Scripts.StaticData;
using System.Collections;
using UnityEngine;

namespace Scripts.Player
{
    public class MovementSpeedSetter : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _staticData;

        private Coroutine _setCurrentHitSpeed;
        private float _startSpeed;
        private float _hitSpeed;
        private float _currentSpeed;
        private float _durationHit;

        public float CurrentSpeed => _currentSpeed;

        private void Awake()
        {
            SetParametrs();
            SetCurrentSpeed(_startSpeed);
        }

        public void SetCurrentHitSpeed()
        {
            if (_setCurrentHitSpeed == null)
            {
                _setCurrentHitSpeed = StartCoroutine(SetHitSpeedForDuration());
            }
        }

        private void SetCurrentSpeed(float speed) => _currentSpeed = speed;

        private void SetParametrs()
        {
            _startSpeed = _staticData.StarMovementSpeed;
            _hitSpeed = _staticData.HitSpeed;
            _durationHit = _staticData.DurationHit;
        }

        private IEnumerator SetHitSpeedForDuration()
        {
            float currentSpeed = _currentSpeed;

            SetCurrentSpeed(_hitSpeed);

            yield return new WaitForSeconds(_durationHit);

            SetCurrentSpeed(currentSpeed);
        }
    }
}