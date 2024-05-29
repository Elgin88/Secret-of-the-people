using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(Animator))]

    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int _move = Animator.StringToHash("IsMove");
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayMove() => _animator.SetBool(_move, true);

        public void StopPlayMove() => _animator.SetBool(_move, false);
    }
}