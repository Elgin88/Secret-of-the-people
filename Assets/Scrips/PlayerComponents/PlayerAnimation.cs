using UnityEngine;

namespace CodeBase.PlayerComponents
{
    internal class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private string _idle = "Idle";
        private string _attack = "Shoot";
        private string _run = "Run";

        private void Update()
        {
        }

        internal void PlayIdle()
        {
            _animator.Play(_idle);
        }

        internal void PlayRun()
        {
            _animator.Play(_run);
        }

        internal void PlayAttack()
        {
            _animator.Play(_attack);
        }
    }
}