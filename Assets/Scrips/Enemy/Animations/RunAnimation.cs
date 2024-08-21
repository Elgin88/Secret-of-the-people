using UnityEngine;

namespace Scripts.Enemy
{
    public class RunAnimation : MonoBehaviour, IAnimation
    {
        [SerializeField] private Animator _animator;

        private bool _isRun = false;

        public bool IsRun => _isRun;

        public void Play()
        {
            SetRun(true);
        }

        public void StopPlay()
        {
            SetRun(false);
        }

        private void SetRun(bool status)
        {
            _isRun = status;
            _animator.SetBool(Static.IsRun, status);
        }
    }
}