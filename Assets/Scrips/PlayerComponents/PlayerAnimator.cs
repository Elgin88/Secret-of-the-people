using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerMover))]

    public class PlayerAnimator : MonoBehaviour
    {
        private const float _baseRunSpeed = 6.5f;
        private static readonly int _run = Animator.StringToHash("IsRun");
        private static readonly int _speedParametr = Animator.StringToHash("SpeedParametr");

        private PlayerMover _playerMover;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMover = GetComponent<PlayerMover>();
        }

        public void PlayRun()
        {
            _animator.SetBool(_run, true);
            _animator.SetFloat(_speedParametr, _playerMover.NormalizeSpeed);
        }

        public void StopPlayRun() => _animator.SetBool(_run, false);
    }
}