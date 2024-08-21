using UnityEngine;

namespace Scripts.Player
{
    public class HitTaker : MonoBehaviour
    {
        [SerializeField] private AnimationSetter _animationsSetter;
        [SerializeField] private HitAnimation _hitAnimation;
        [SerializeField] private Mover _mover;

        public bool IsHit => _hitAnimation.IsHit;

        public void TakeHit()
        {
            _animationsSetter.PlayHit();
        }
    }
}