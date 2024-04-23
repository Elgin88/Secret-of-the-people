using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(Animator))]

    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string _run = "IsRun";

        public void StartRun() => _animator.SetBool(_run, true);

        public void StopRun() => _animator.SetBool(_run, false);

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}