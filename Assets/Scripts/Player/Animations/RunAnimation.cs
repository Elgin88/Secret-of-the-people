using Scripts.StaticData;
using UnityEngine;

namespace Player.Animations
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpeedSetter))]
    public class RunAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private SpeedSetter _speedSetter;
        [SerializeField] private Animator _animator;

        public void PlayRun()
        {
            SetAnimationSpeed();
            _animator.SetBool(Static.IsRunHash, true);
        }

        public void StopPlayRun()
        {
            _animator.SetBool(Static.IsRunHash, false);
        }

        private void SetAnimationSpeed() => _animator.SetFloat(Static.RunHash, _speedSetter.CurrentSpeed / _staticData.AnimationBaseRunSpeed);
    }
}