using UnityEngine;
using Scripts.Static;

namespace Scripts.PlayerComponents
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Animator _animator;

        private static readonly int _run = Animator.StringToHash(StaticPlayerParametrs.IsRun);
        private static readonly int _speedParametr = Animator.StringToHash(StaticPlayerParametrs.SpeedParametr);
        private static readonly int _takeDamdage = Animator.StringToHash(StaticPlayerParametrs.TakeDamage);

        public bool IsHit { get; internal set; }

        public void PlayRun()
        {
            Debug.Log("Дописать здесь IsHit");
            Debug.Log("Перенести сюда NormalizeSpeed");

            AnimationRunOn();
            SetSpeedOfAnimation();
        }

        public void AnimationRunOff() => _animator.SetBool(_run, false);

        public void PlayTakeDamage() => _animator.Play(_takeDamdage);

        private void OnTakeDamageEnded() => PlayRun();
        private void SetSpeedOfAnimation() => _animator.SetFloat(_speedParametr, _playerMover.NormalizeSpeed);
        private void AnimationRunOn() => _animator.SetBool(_run, true);
    }
}