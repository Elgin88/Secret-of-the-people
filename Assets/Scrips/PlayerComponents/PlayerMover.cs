using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(PlayerAnimator))]

    public class PlayerMover : MonoBehaviour
    {
        private const float _startSpeed = 7;
        private const float _deltaRotation = 2500;
        private const float _baseSpeed = 6.5f;
        private float _currentSpeed = 0;
        private Vector3 _targetDirection = Vector3.zero;
        private Vector2 _axis = Vector2.zero;
        private Quaternion _targetRotaion = Quaternion.identity;
        private Transform _transform;
        private CharacterController _characterController;
        private AllServices _allServices;
        private PlayerAnimator _animator;

        public float NormalizeSpeed => _startSpeed / _baseSpeed;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<PlayerAnimator>();
            _allServices = AllServices.Container;
        }

        private void LateUpdate()
        {
            _targetDirection = Vector3.zero;
            _currentSpeed = 0;
            _axis = _allServices.Get<IInputService>().Axis;

            if (_axis != Vector2.zero)
            {
                _currentSpeed = _startSpeed;
                _animator.PlayRun();
                SetTargetDirection(_axis);
                SetTargetRotation(_axis);
                ChangePlayerPosition(_targetDirection, _currentSpeed);
                ChangePlayerRotation(_targetRotaion, _deltaRotation);
            }
            else
            {
                _animator.StopPlayRun();
            }
        }

        private void SetTargetRotation(Vector2 axis) => _targetRotaion = Quaternion.LookRotation(new Vector3(axis.x, 0, axis.y));

        private void SetTargetDirection(Vector2 axis) => _targetDirection = new Vector3(axis.x, 0, axis.y);

        private void ChangePlayerPosition(Vector3 targetDirection, float currentSpeed) => _characterController.Move(targetDirection * currentSpeed * Time.deltaTime);

        private void ChangePlayerRotation(Quaternion targetRotation, float deltaRotation) => _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, deltaRotation * Time.deltaTime);
    }
}