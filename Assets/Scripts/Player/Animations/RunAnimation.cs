using Player.Logic;
using StaticData;
using UnityEngine;

namespace Player.Animations
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpeedMovementSetter))]

    public class RunAnimation : MonoBehaviour
    {
        [SerializeField] private SpeedMovementSetter _speedSetter;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private Animator _animator;

        public void PlayRun()
        {
            SetAnimationSpeed();
            _animator.SetBool(PlayerStatic.IsRunHash, true);
        }

        public void StopPlayRun()
        {
            _animator.SetBool(PlayerStatic.IsRunHash, false);
        }

        private void SetAnimationSpeed() => _animator.SetFloat(PlayerStatic.RunHash, _speedSetter.CurrentSpeed / _staticData.AnimationBaseRunSpeed);
    }
}