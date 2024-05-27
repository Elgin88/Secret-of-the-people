using Scripts.CodeBase.Infractructure;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerMover : MonoBehaviour
    {
        private float _baseSpeed = 4;
        private float _currentSpeed = 0;
        private float _deltaRotation = 2500;
        private Vector3 _targetDirection = Vector3.zero;
        private Vector2 _axis = Vector2.zero;
        private Quaternion _targetRotaion = Quaternion.identity;
        private CharacterController _characterController;
        private AllServices _allServices;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _allServices = AllServices.Container;

            _currentSpeed = _baseSpeed;
        }

        private void LateUpdate()
        {
            _targetDirection = Vector3.zero;
            _axis = _allServices.Get<IInputService>().Axis;

            if (_axis != Vector2.zero)
            {
                SetTargetDirection(_axis);
                SetTargetRotation(_axis);
                ChangePlayerPosition(_targetDirection, _currentSpeed);
                ChangePlayerRotation(_targetRotaion, _deltaRotation);
            }
        }

        private void SetTargetRotation(Vector2 axis) => _targetRotaion = Quaternion.LookRotation(new Vector3(axis.x, 0, axis.y));

        private void SetTargetDirection(Vector2 axis) => _targetDirection = new Vector3(axis.x, 0, axis.y);

        private void ChangePlayerPosition(Vector3 targetDirection, float currentSpeed) => _characterController.Move(targetDirection * currentSpeed * Time.deltaTime);

        private void ChangePlayerRotation(Quaternion targetRotation, float deltaRotation) => transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, deltaRotation * Time.deltaTime);
    }
}