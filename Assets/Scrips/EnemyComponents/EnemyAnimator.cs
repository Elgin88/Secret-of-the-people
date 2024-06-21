using Scripts.Logic;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private const float _baseAnimationMoveSpeed = 6f;
        private static readonly int _attack = Animator.StringToHash(StaticEnemyParametrs.IsAttack);
        private static readonly int _move = Animator.StringToHash(StaticEnemyParametrs.IsMove);
        private static readonly int _speedParametr = Animator.StringToHash(StaticEnemyParametrs.MoveParametr);

        public void PlayMove()
        {
            _animator.SetFloat(_speedParametr, GetNormalizeMoveSpeed());
            _animator.SetBool(_move, true);
        }

        public void StopPlayMove() => _animator.SetBool(_move, false);

        public void PlayAttack() => _animator.SetTrigger(_attack);

        public void StopPlayAttack() => _animator.ResetTrigger(_attack);

        private float GetNormalizeMoveSpeed() => _baseAnimationMoveSpeed / _agentMoveToPlayer.CurrentSpeed;
    }
}