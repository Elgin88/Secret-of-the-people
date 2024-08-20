using UnityEngine;

namespace Scripts.Player
{
    public class AnimationSetter : MonoBehaviour
    {
        [SerializeField] private RunAnimation _runAnimation;
        [SerializeField] private HitAnimation _hitAnimation;

        private void Awake() => PlayEdle();

        private void PlayEdle()
        {
            StopPlayRun();
            StopPlayHit();
        }

        public void PlayRun()
        {
            if (!IsHit())
            {
                _runAnimation.PlayRun();
            }
        }

        public void PlayHit()
        {
            PlayEdle();
            _hitAnimation.PlayHit();
        }

        public void StopPlayHit() => _hitAnimation.StopPlayHit();

        public void StopPlayRun() => _runAnimation.StopPlayRun();

        private bool IsHit() => _hitAnimation.IsHit;
    }
}