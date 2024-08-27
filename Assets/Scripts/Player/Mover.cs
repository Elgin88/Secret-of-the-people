using Infrastructure.Services;
using Infrastructure.Services.Input;
using Player.Animations;
using StaticData;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpeedSetter))]
    [RequireComponent(typeof(HealthChanger))]
    [RequireComponent(typeof(AnimationSetter))]
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private AnimationSetter _animationsSetter;
        [SerializeField] private HealthChanger _healthSetter;
        [SerializeField] private SpeedSetter _speedSetter;

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