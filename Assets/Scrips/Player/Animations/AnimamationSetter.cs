using UnityEngine;

namespace Scripts.Player
{
    public class AnimamationSetter : MonoBehaviour
    {
        [SerializeField] private RunAnimation _runAnimation;
        [SerializeField] private HitAnimation _hitAnimation;

        private bool _isHit = false;

        public void PlayRun()
        {
            if (!_isHit)
            {
                _runAnimation.PlayRun();
            }
        }

        public void PlayHit()
        {
            _isHit = true;
            _hitAnimation.PlayHit();
        }

        public void StopPlayRun() => _runAnimation.StopPlayRun();

        public void StopPlayHit() => _hitAnimation.StopPlayHit();

        private void OnHitEnded() => _isHit = false;
    }
}