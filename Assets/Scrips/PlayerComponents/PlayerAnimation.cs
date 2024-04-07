using UnityEngine;

namespace CodeBase.PlayerComponents
{
    internal class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMover _playerMover;

        private string _run = "IsRun";

        internal void StartRun()
        {
            _animator.SetBool(_run, true);
        }

        internal void StopRun()
        {
            _animator.SetBool(_run, false);
        }
    }
}