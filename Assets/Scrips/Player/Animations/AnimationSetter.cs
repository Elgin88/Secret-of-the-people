using UnityEngine;

namespace Scripts.Player
{
    public class AnimationSetter : MonoBehaviour
    {
        [SerializeField] private AnimationStateMaschine _animatorStateMashine;

        public void PlayRunAnimation()
        {
            _animatorStateMashine.PlayHit();
        }

        public void PlayHitAnimation()
        {
            _animatorStateMashine.PlayHit();
        }

        public void PlayDeadAnimation()
        {
            _animatorStateMashine.PlayDead();
        }
    }
}