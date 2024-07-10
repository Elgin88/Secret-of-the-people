using Scripts.Static;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Animator _animator;

        private float _baseRunSpeedInAnimation = 6.5f;
        private static readonly int _run = Animator.StringToHash(StaticPlayerParametrs.IsRun);
        private static readonly int _runParametr = Animator.StringToHash(StaticPlayerParametrs.RunParametr);
        private static readonly int _hit = Animator.StringToHash(StaticPlayerParametrs.Hit);
        private bool _isHiting;

        public bool IsHiting => _isHiting;

        public void PlayAnimationRun()
        {
            RunOn();
            SetSpeedOfRunAnimation();
        }

        public void StopPlayAnimationRun()
        {
            _animator.SetBool(_run, false);
        }

        public void PlayHit()
        {
            PlayAnimationHit();
            SetIsHitingTrue();
        }

        private void OnHitEnded()
        {
            SetIsHitingFalse();
        }

        private void RunOn() => _animator.SetBool(_run, true);
        private void PlayAnimationHit() => _animator.Play(_hit);
        private void SetSpeedOfRunAnimation() => _animator.SetFloat(_runParametr, _playerMover.StartSpeed / _baseRunSpeedInAnimation);
        private void SetIsHitingTrue() => _isHiting = true;
        private void SetIsHitingFalse() => _isHiting = false;
    }
}