using Scripts.CodeBase.Infractructure;
using Scripts.CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.PlayerComponents
{
    internal class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;
        private Vector3 _targetPosition;
        private Vector3 _currentPosition;
        private Quaternion _targetRotation;
        private Quaternion _currentRotation;
        private float _currentMovementSpeed;

        private void Awake()
        {
            _inputService = Game.InputService;

            _targetPosition = new Vector3();

            _currentPosition = transform.position;
            _currentMovementSpeed = _movementSpeed;
        }

        private void Update()
        {
            _currentPosition = transform.position;
            _currentRotation = transform.rotation;

            _targetPosition = new Vector3(transform.position.x + _inputService.Axis.x, 0, transform.position.z + _inputService.Axis.y);
            _targetPosition = Vector3.MoveTowards(_currentPosition, _targetPosition, _currentMovementSpeed * Time.deltaTime);

            if (_targetPosition != _currentPosition)
            {
                _targetRotation = Quaternion.LookRotation(_targetPosition - transform.position, Vector3.up);
            }
            else
            {
                _targetRotation = _currentRotation;
            }

            _player.SetPosition(_targetPosition);
            _player.SetRotation(_targetRotation);
        }
    }
}