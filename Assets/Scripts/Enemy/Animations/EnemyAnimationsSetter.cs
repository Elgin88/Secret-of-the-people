using System;
using UnityEngine;

namespace Enemy.Animations
{
    [RequireComponent(typeof(AttackAnimation))]
    [RequireComponent(typeof(HitAnimation))]
    [RequireComponent(typeof(RunAnimation))]

    public class EnemyAnimationsSetter : MonoBehaviour, IEnemyAnimationSetter
    {
        private AttackAnimation _attackAnimation;
        private RunAnimation _runAnimation;
        private HitAnimation _hitAnimation;

        private void Start() => PlayIdle();

        private void Awake()
        {
            _attackAnimation = GetComponent<AttackAnimation>();
            _runAnimation = GetComponent<RunAnimation>();
            _hitAnimation = GetComponent<HitAnimation>();
        }

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

        private void PlayIdle()
        {
            StopPlayRun();
            StopPlayAttack();
            StopPlayHit();
        }
    }
}