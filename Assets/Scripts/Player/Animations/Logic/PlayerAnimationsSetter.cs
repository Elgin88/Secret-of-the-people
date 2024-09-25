using UnityEngine;

namespace Player.Animations.Logic
{
    [RequireComponent(typeof(HitAnimation))]
    [RequireComponent(typeof(RunAnimation))]

    public class PlayerAnimationsSetter : MonoBehaviour, IPlayerAnimationsSetter
    {
        [SerializeField] private RunAnimation _runAnimation;
        [SerializeField] private HitAnimation _hitAnimation;

        private void Awake() => PlayEdle();

        public void PlayRun()
        {
            _runAnimation.PlayRun();
        }

        public void PlayHit()
        {
            _hitAnimation.PlayHit();
        }

        public void StopPlayHit()
        {
            _hitAnimation.StopPlayHit();
        }

        public void StopPlayRun()
        {
            _runAnimation.StopPlayRun();
        }

        private void PlayEdle()
        {
            StopPlayRun();
            StopPlayHit();
        }
    }
}