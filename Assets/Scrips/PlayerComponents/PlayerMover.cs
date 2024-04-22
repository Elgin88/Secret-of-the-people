using Scripts.CodeBase.Infractructure.Services;
using Scripts.CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.PlayerComponents
{
    [RequireComponent(typeof(PlayerAnimation))]
    [RequireComponent(typeof(Player))]

    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private PlayerAnimation _playerAnimation;
        private IInputService _inputService;
        private Quaternion _targetRotation;
        private Quaternion _currentRotation;
        private Vector3 _targetPosition = new Vector3();
        private Vector3 _currentPosition;
        private Player _player;
        private float _currentMovementSpeed;
        private bool _isRun;

        public bool IsRun => _isRun;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();

            _playerAnimation = GetComponent<PlayerAnimation>();
            _player = GetComponent<Player>();

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