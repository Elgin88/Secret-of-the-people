using Scripts.CodeBase.Infractructure;
using Scripts.CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.PlayerComponents
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private Player _player;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;
        private Quaternion _targetRotation;
        private Quaternion _currentRotation;
        private Vector3 _targetPosition;
        private Vector3 _currentPosition;
        private float _currentMovementSpeed;
        private bool _isRun;

        public bool IsRun => _isRun;

        private void Awake()
        {
            _inputService = Game.InputService;
            _targetPosition = new Vector3();

            _currentMovementSpeed = _movementSpeed;
        }

        private void Update()
        {
            _currentPosition = transform.position;
            _currentRotation = transform.rotation;

            SetTargetPosition();
            SetTargetRotation();
            SetIsRunStatus();

            TryPlayRunAnimation();

            _player.SetPosition(_targetPosition);
            _player.SetRotation(_targetRotation);
        }

        private void SetTargetPosition()
        {
            _targetPosition = new Vector3(transform.position.x + _inputService.Axis.x, 0, transform.position.z + _inputService.Axis.y);
            _targetPosition = Vector3.MoveTowards(_currentPosition, _targetPosition, _currentMovementSpeed * Time.deltaTime);
        }

        private void SetTargetRotation()
        {
            if (_targetPosition != _currentPosition)
            {
                _targetRotation = Quaternion.LookRotation(_targetPosition - transform.position, Vector3.up);
            }
            else
            {
                _targetRotation = _currentRotation;
            }
        }

        private void SetIsRunStatus()
        {
            if (_currentPosition == _targetPosition)
            {
                _isRun = false;
            }
            else
            {
                _isRun = true;
            }
        }

        private void TryPlayRunAnimation()
        {
            if (_isRun)
            {
                _playerAnimation.StartRun();
            }
            else
            {
                _playerAnimation.StopRun();
            }
        }
    }
}