using CodeBase.Infractructure;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.PlayerComponents
{
    internal class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movemenSpeed;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 movementDirection = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementDirection = _camera.transform.TransformDirection(_inputService.Axis);
                movementDirection.y = 0;
                movementDirection.Normalize();

                transform.forward = movementDirection;
            }

            movementDirection += Physics.gravity;

            _characterController.Move(movementDirection * _movemenSpeed * Time.deltaTime) ;
        }
    }
}