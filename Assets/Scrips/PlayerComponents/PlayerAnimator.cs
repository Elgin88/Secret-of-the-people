using UnityEngine;
using Scripts.Static;

namespace Scripts.PlayerComponents
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Animator _animator;

        private float _baseRunAnimationSpeed = 6.5f;
        private static readonly int _run = Animator.StringToHash(StaticPlayerParametrs.IsRun);
        private static readonly int _speedParametr = Animator.StringToHash(StaticPlayerParametrs.RunParametr);
        private static readonly int _hit = Animator.StringToHash(StaticPlayerParametrs.Hit);
        private bool _isHiting;

        public bool IsHiting => _isHiting;

        public void PlayAnimationRun()
        {
            AnimatorRunOn();
            SetSpeedOfAnimation();
        }

        public void PlayTakeDamage()
        {
            PlayAnimationHit();
            SetIsHitingTrue();
        }

        private void OnHitEnded()
        {
            SetIsHitingFalse();
        }

        private void PlayAnimationHit() => _animator.Play(_hit);
        private void SetSpeedOfAnimation() => _animator.SetFloat(_speedParametr, _playerMover.StartSpeed / _baseRunAnimationSpeed);
        private void SetIsHitingTrue() => _isHiting = true;
        private void SetIsHitingFalse() => _isHiting = false;
        private void AnimatorRunOn() => _animator.SetBool(_run, true);
        public void AnimatorRunOff() => _animator.SetBool(_run, false);
    }
}