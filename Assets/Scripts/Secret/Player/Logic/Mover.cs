using Secret.Infrastructure.Services;
using Secret.Infrastructure.Services.Input;
using Secret.Player.Animations.Logic;
using Secret.Player.StaticData;
using UnityEngine;

namespace Secret.Player.Logic
{
    [RequireComponent(typeof(PlayerAnimationsSetter))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(SpeedMovementSetter))]
    [RequireComponent(typeof(HealthChanger))]

    public class Mover : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationsSetter _animationsSetter;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private SpeedMovementSetter _speedSetter;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private HealthChanger _healthSetter;

        private AllServices _allServices;
        private Quaternion _targetRotation;
        private Vector3 _targetDirection;
        private Vector2 _axis;
        private float _deltaRotation;

        private void Awake()
        {
            SetDeltaRotation();
            SetAllServices();
        }

        private void LateUpdate()
        {
            GetAxis();

            if (_axis != Vector2.zero & IsAlive())
            {
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
        private void SetTargetRotation() => _targetRotation = Quaternion.LookRotation(new Vector3(_axis.x, 0, _axis.y));
        private void SetTargetDirection() => _targetDirection = new Vector3(_axis.x, 0, _axis.y);
        private void ChangePosition() => _characterController.Move(motion: _targetDirection * (_speedSetter.CurrentSpeed * Time.deltaTime));
        private void ChangeRotation() => transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _deltaRotation * Time.deltaTime);
        private void SetDeltaRotation() => _deltaRotation = _staticData.RotationSpeed;
        private bool IsAlive() => _healthSetter.CurrentHealth > 0;
    }
}