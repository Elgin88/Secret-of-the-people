using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerAnimator _playerAnimator;

        private const float _startSpeed = 7;
        private const float _deltaRotation = 2500;
        private const float _hitSpeedCoefficient = 0.5f;
        private float _currentSpeed;
        private AllServices _allServices;
        private Quaternion _targetRotaion;
        private Vector3 _targetDirection;
        private Vector2 _axis;

        public float StartSpeed => _startSpeed;

        private void Awake()
        {
            SetAllServices();
        }

        private void LateUpdate()
        {
            ResetCurrentSpeed();
            GetAxis();

            if (_axis != Vector2.zero)
            {
                SetCurrentSpeed();
                AnimatorPlayRun();
                SetTargetDirection(_axis);
                SetTargetRotation(_axis);
                ChangePlayerPosition(_targetDirection, _currentSpeed);
                ChangePlayerRotation(_targetRotaion, _deltaRotation);
            }
            else
            {
                AnimatorStopPlayRun();
            }

            if (PlayerIsHit())
            {
                SetHitSpeed();
            }
        }

        private void SetAllServices() => _allServices = AllServices.Container;
        private void GetAxis() => _axis = _allServices.Get<IInputService>().Axis;
        private void ResetCurrentSpeed() => _currentSpeed = 0;
        private void AnimatorStopPlayRun() => _playerAnimator.AnimatorRunOff();
        private void SetCurrentSpeed() => _currentSpeed = _startSpeed;
        private void AnimatorPlayRun() => _playerAnimator.PlayAnimationRun();
        private bool PlayerIsHit() => _playerAnimator.IsHiting;
        private void SetHitSpeed() => _currentSpeed = _currentSpeed * _hitSpeedCoefficient;
        private void SetTargetRotation(Vector2 axis) => _targetRotaion = Quaternion.LookRotation(new Vector3(axis.x, 0, axis.y));
        private void SetTargetDirection(Vector2 axis) => _targetDirection = new Vector3(axis.x, 0, axis.y);
        private void ChangePlayerPosition(Vector3 targetDirection, float currentSpeed) => _characterController.Move(targetDirection * currentSpeed * Time.deltaTime);
        private void ChangePlayerRotation(Quaternion targetRotation, float deltaRotation) => _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, deltaRotation * Time.deltaTime);
    }
}