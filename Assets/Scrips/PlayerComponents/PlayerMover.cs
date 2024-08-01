using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private PlayerHealth _playerHealth;

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

            if (_axis != Vector2.zero & IsPlayerAlive())
            {
                SetCurrentSpeed();
                SetCurrentHitSpeed();
                AnimatorPlayRun();
                SetTargetDirection(_axis);
                SetTargetRotation(_axis);
                ChangePosition(_targetDirection, _currentSpeed);
                ChangeRotation(_targetRotaion, _deltaRotation);
            }
            else
            {
                AnimatorStopPlayRun();
            }
        }

        private void SetCurrentHitSpeed()
        {
            if (PlayerIsHiting())
            {
                _currentSpeed = _currentSpeed * _hitSpeedCoefficient;
            }
        }

        private bool IsPlayerAlive() => !_playerHealth.IsDead;

        private void SetAllServices() => _allServices = AllServices.Container;

        private void GetAxis() => _axis = _allServices.Get<IInputService>().Axis;

        private void ResetCurrentSpeed() => _currentSpeed = 0;

        private void AnimatorStopPlayRun() => _playerAnimator.StopPlayRunAnimation();

        private void SetCurrentSpeed() => _currentSpeed = _startMoveSpeed;

        private void AnimatorPlayRun() => _playerAnimator.PlayRunAnimation();

        private bool PlayerIsHiting() => _playerAnimator.IsHiting;

        private void SetTargetRotation(Vector2 axis) => _targetRotaion = Quaternion.LookRotation(new Vector3(axis.x, 0, axis.y));

        private void SetTargetDirection(Vector2 axis) => _targetDirection = new Vector3(axis.x, 0, axis.y);

        private void ChangePosition(Vector3 targetDirection, float currentSpeed) => _characterController.Move(targetDirection * currentSpeed * Time.deltaTime);

        private void ChangeRotation(Quaternion targetRotation, float deltaRotation) => _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, deltaRotation * Time.deltaTime);

        private void SetHitSpeedCoefficient() => _hitSpeedCoefficient = _staticData.CoefficientDownSpeedAfterHit;

        private void SetDeltaRotation() => _deltaRotation = _staticData.RotationSpeed;

        private void SetStartMoveSpeed() => _startMoveSpeed = _staticData.RunSpeed;
    }
}