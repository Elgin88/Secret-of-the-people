using UnityEngine;

namespace Enemy.Animations
{
    [RequireComponent(typeof(HitAnimation))]
    [RequireComponent(typeof(RunAnimation))]
    [RequireComponent(typeof(AttackAnimation))]
    public class AnimationSetter : MonoBehaviour, IAnimationSetter
    {
        [SerializeField] private AttackAnimation _attackAnimation;
        [SerializeField] private RunAnimation _runAnimation;
        [SerializeField] private HitAnimation _hitAnimation;

        private void Start() => PlayIdle();

        public void PlayIdle()
        {
            StopPlayRun();
            StopPlayAttack();
            StopPlayHit();
        }

        public void PlayRun()
        {
            if (!_hitAnimation.IsHit)
            {
                PlayIdle();

                _runAnimation.Play();
            }
        }

        public void PlayAttack()
        {
            if (!_hitAnimation.IsHit)
            {
                PlayIdle();

                _attackAnimation.Play();
            }
        }

        public void PlayHit()
        {
            PlayIdle();

            _hitAnimation.Play();
        }

        public void StopPlayRun() => _runAnimation.StopPlay();

        public void StopPlayAttack() => _attackAnimation.StopPlay();

        public void StopPlayHit() => _hitAnimation.StopPlay();
    }
}