using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Player
{
    public class AnimationsSetter : MonoBehaviour
    {
        [SerializeField] private AnimationChooserDeathParametr _deathParametr;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private Animator _animator;
        [SerializeField] private Mover _playerMover;

        private float _baseRunSpeedAnimation;
        private readonly int _runHash = Animator.StringToHash(Static
            .IsRun);
        private readonly int _runParametrHash
            = Animator.StringToHash(Static.AnimatorRunParametr);
        private readonly int _hitHash = Animator.StringToHash(Static.Hit);
        private readonly int _deadHash = Animator.StringToHash(Static.Dead);
        private bool _isHiting;

        public bool IsHiting => _isHiting;

        private void Awake()
        {
            _baseRunSpeedAnimation = _staticData.AnimationBaseRunSpeed;
        }

        public void PlayRunAnimation()
        {
            SetRunParametr();
            PlayRun();
        }

        public void StopPlayRunAnimation()
        {
            _animator.SetBool(_runHash, false);
        }

        public void PlayHitAnimation()
        {
            SetIsHiting();
            PlayHit();
        }

        public void PlayDeadAnimation()
        {
            _animator.SetFloat(_deathParametr.GetDeathHash(), 1);
            _animator.Play(_deadHash);
        }

        public void StopPlayDeadAnimation()
        {
            _animator.SetFloat(_deathParametr.GetDeathHash(), 0);
        }

        private void OnHitEnded() => ResetIsHiting();

        private void PlayHit() => _animator.Play(_hitHash);

        private void SetIsHiting() => _isHiting = true;

        private void ResetIsHiting() => _isHiting = false;

        private void PlayRun() => _animator.SetBool(_runHash, true);

        private void SetRunParametr() => _animator.SetFloat(_runParametrHash, _playerMover.StartMoveSpeed / _baseRunSpeedAnimation);
    }
}