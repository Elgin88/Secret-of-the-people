using Secret.Player.Logic;
using Secret.Player.StaticData;
using UnityEngine;

namespace Secret.Player.Animations
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

        private void SetAnimationSpeed() => _animator.SetFloat(PlayerStatic.RunParametrHash, _speedSetter.CurrentSpeed / _staticData.AnimationBaseRunSpeed);
    }
}