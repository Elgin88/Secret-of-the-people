using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(Animator))]

    public class PlayerAnimation : MonoBehaviour
    {
        private const string _run = "IsRun";
        private Animator _animator;

        public void StartRun() => _animator.SetBool(_run, true);

        public void StopRun() => _animator.SetBool(_run, false);

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}