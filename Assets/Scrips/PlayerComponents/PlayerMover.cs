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
        private Quaternion _targetRotation;
        private float _currentSpeed;

        private void Awake()
        {
            _targetPosition = new Vector3();

            _inputService = Game.InputService;
            _currentSpeed = _movementSpeed;
        }

        private void Update()
        {
            _targetPosition = new Vector3(transform.position.x + _inputService.Axis.x, 0, transform.position.z + _inputService.Axis.y);
        }
    }
}