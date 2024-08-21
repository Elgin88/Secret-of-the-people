using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private AnimationSetter _animationsSetter;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private HealthChanger _healthSetter;
        [SerializeField] private HitTaker _hitTaker;

        private AllServices _allServices;
        private Quaternion _targetRotaion;
        private Vector3 _targetDirection;
        private Vector2 _axis;
        private float _startMoveSpeed;
        private float _deltaRotation;
        private float _hitSpeedCoefficient;
        private float _currentSpeed;

        public float StartMoveSpeed => _startMoveSpeed;

        private void Awake()
        {
            SetStartMoveSpeed();
            SetDeltaRotation();
            SetHitSpeedCoefficient();
            SetAllServices();
        }

        private void LateUpdate()
        {
            ResetCurrentSpeed();
            GetAxis();

            if (_axis != Vector2.zero & IsAlive())
            {
                SetCurrentSpeed();
                TrySetCurrentHitSpeed();
                SetTargetDirection();
                SetTargetRotation();
                ChangePosition();
                ChangeRotation();
                PlayAnimationRun();
            }
            else
            {
                StopPlayAnimationRun();
            }
        }

        private void PlayAnimationRun() => _animationsSetter.PlayRun();

        private void StopPlayAnimationRun() => _animationsSetter.StopPlayRun();

        private void SetAllServices() => _allServices = AllServices.Container;

        private void GetAxis() => _axis = _allServices.Get<IInputService>().Axis;

        private void ResetCurrentSpeed() => _currentSpeed = 0;

        private void SetCurrentSpeed() => _currentSpeed = _startMoveSpeed;

        private void SetTargetRotation() => _targetRotaion = Quaternion.LookRotation(new Vector3(_axis.x, 0, _axis.y));

        private void SetTargetDirection() => _targetDirection = new Vector3(_axis.x, 0, _axis.y);

        private void ChangePosition() => _characterController.Move(_targetDirection * _currentSpeed * Time.deltaTime);

        private void ChangeRotation() => transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotaion, _deltaRotation * Time.deltaTime);

        private void SetHitSpeedCoefficient() => _hitSpeedCoefficient = _staticData.CoefficientDownSpeedAfterHit;

        private void SetDeltaRotation() => _deltaRotation = _staticData.RotationSpeed;

        private void SetStartMoveSpeed() => _startMoveSpeed = _staticData.RunSpeed;

        private bool IsAlive() => _healthSetter.CurrentHealth > 0;

        private void TrySetCurrentHitSpeed()
        {
            if (_hitTaker.IsHit)
            {
                _currentSpeed *= _hitSpeedCoefficient;
            }
        }
    }
}