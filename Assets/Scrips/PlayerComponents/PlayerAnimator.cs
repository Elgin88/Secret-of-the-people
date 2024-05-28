using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerMover))]

    public class PlayerAnimator : MonoBehaviour
    {
        private const float _baseRunSpeed = 6;
        private static readonly int _run = Animator.StringToHash("IsRun");
        private static readonly int _speedParametr = Animator.StringToHash("SpeedParametr");

        private PlayerMover _playerMover;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            PlayRunAnimation();
        }

        private void PlayRunAnimation()
        {
            if (_playerMover.CurrentSpeed > 0)
            {
                StartRun();
            }
            else
            {
                StopRun();
            }
        }

        private void StartRun()
        {
            _animator.SetBool(_run, true);
            _animator.SetFloat(_speedParametr, _playerMover.Speed / _baseRunSpeed);
        }

        private void StopRun() => _animator.SetBool(_run, false);
    }
}