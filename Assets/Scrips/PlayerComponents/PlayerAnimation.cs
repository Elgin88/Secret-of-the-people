using UnityEngine;

namespace CodeBase.PlayerComponents
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMover _playerMover;

        private string _run = "IsRun";

        public void StartRun()
        {
            _animator.SetBool(_run, true);
        }

        public void StopRun()
        {
            _animator.SetBool(_run, false);
        }
    }
}