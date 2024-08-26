using Player.Animations;
using UnityEngine;

namespace Player
{
    public class HitTaker : MonoBehaviour
    {
        [SerializeField] private AnimationSetter _animationsSetter;
        [SerializeField] private HitAnimation _hitAnimation;

        public bool IsHit => _hitAnimation.IsHit;

        public void Hit()
        {
            _animationsSetter.PlayHit();
        }
    }
}