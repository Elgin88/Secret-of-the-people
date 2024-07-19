using Scripts.StaticData;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerStaticData _staticData;

        private float _baseSrunSpeedAnimation;
        private readonly int _runHash = Animator.StringToHash(PlayerStatic
            .IsRun);
        private readonly int _runParametrHash
            = Animator.StringToHash(PlayerStatic.RunParametr);
        private readonly int _hitHash = Animator.StringToHash(PlayerStatic.Hit);
        private int _deadHash = Animator.StringToHash(PlayerStatic.Dead);
        private bool _isHiting;

        public bool IsHiting => _isHiting;

        private void Awake() => _baseSrunSpeedAnimation = _staticData.AnimationBaseRunSpeed;

        public void PlayRunAnimation()
        {
            SetRunParametr();
            PlayRun();
        }

        public void StopPlayRunAnimation() => _animator.SetBool(_runHash, false);

        public void PlayHitAnimation()
        {
            SetIsHiting();
            PlayHit();
        }

        public void PlayDead() => _animator.Play(_deadHash);

        private void OnHitEnded() => ResetIsHiting();

        private void PlayHit() => _animator.Play(_hitHash);

        private void SetIsHiting() => _isHiting = true;

        private void ResetIsHiting() => _isHiting = false;

        private void PlayRun() => _animator.SetBool(_runHash, true);

        private void SetRunParametr() => _animator.SetFloat(_runParametrHash, _playerMover.StartMoveSpeed / _baseSrunSpeedAnimation);
    }
}