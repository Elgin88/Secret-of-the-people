using System;
using System.Collections;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Player
{
    public class MovementSpeedSetter : MonoBehaviour, IMovementSpeedSetter
    {
        [SerializeField] private PlayerStaticData _staticData;

        private float _startSpeed;
        private float _currentSpeed;

        public float CurrentSpeed => _currentSpeed;

        private void Awake()
        {
            SetStartSpeed();
            SetCurrentSpeed(_startSpeed);
        }

        public void SetCurrentSpeed(float speed)
        {
            _currentSpeed = speed;
        }

        public void SetCurrentHitSpeed(float hitSpeed, float duration)
        {
            _currentSpeed = hitSpeed;

            ComebackCurrentSpeed(duration);
        }

        private void ComebackCurrentSpeed(float duration) => StartCoroutine(SetCurrentSpeedAfterDelay(duration));

        private IEnumerator SetCurrentSpeedAfterDelay(float duration)
        {
            yield return new WaitForSeconds(duration);

            SetCurrentSpeed(_startSpeed);
        }

        private void SetStartSpeed() => _startSpeed = _staticData.StarMovementSpeed;
    }
}