using UnityEngine;

namespace Scripts.Player
{
    public class HitTaker : MonoBehaviour
    {
        [SerializeField] private AnimationSetter _animationsSetter;

        public void TakeHit()
        {
            _animationsSetter.PlayHit();
        }
    }
}