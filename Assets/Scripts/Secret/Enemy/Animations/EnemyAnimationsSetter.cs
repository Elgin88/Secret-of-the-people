using UnityEngine;

namespace Secret.Enemy.Animations
{
    public class EnemyAnimationsSetter : MonoBehaviour
    {
        [SerializeField] private AttackAnimation _attackAnimation;
        [SerializeField] private RunAnimation _runAnimation;
        [SerializeField] private HitAnimation _hitAnimation;

        public void PlayRun()
        {
            PlayIdle();
            _runAnimation.Play();
        }

        public void PlayAttack()
        {
            PlayIdle();
            _attackAnimation.Play();
        }

        public void PlayHit()
        {
            PlayIdle();
            _hitAnimation.Play();
        }

        public void StopPlayRun() => _runAnimation.StopPlay();

        public void StopPlayAttack() => _attackAnimation.StopPlay();

        public void StopPlayHit() => _hitAnimation.StopPlay();

        public void PlayIdle()
        {
            StopPlayRun();
            StopPlayAttack();
            StopPlayHit();
        }
    }
}