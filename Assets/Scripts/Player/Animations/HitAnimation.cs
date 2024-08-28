using UnityEngine;

namespace Player.Animations
{
    [RequireComponent(typeof(Animator))]

    public class HitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayHit() => _animator.SetBool(PlayerStatic.IsHitHash, true);

        public void StopPlayHit() => _animator.SetBool(PlayerStatic.IsHitHash, false);

        private void OnHitEnded() => StopPlayHit();
    }
}