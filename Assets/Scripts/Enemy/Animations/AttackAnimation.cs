using UnityEngine;

namespace Scripts.Enemy
{
    public class AttackAnimation : MonoBehaviour, IAnimation
    {
        [SerializeField] private Animator _animator;

        private bool _isAttack = false;

        public bool IsAttack => _isAttack;

        public void Play()
        {
            SetAttack(true);
        }

        public void StopPlay()
        {
            SetAttack(false);
        }

        private void SetAttack(bool status)
        {
            _isAttack = status;
            _animator.SetBool(global::Enemy.Static.IsAttack, status);
        }
    }
}