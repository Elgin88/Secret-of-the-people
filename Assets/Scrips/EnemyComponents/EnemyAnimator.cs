using Scripts.Static;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] public const float _baseAnimationMoveSpeed = 1f;

        private static readonly int _attack = Animator.StringToHash(StaticEnemyParametrs.IsAttack);
        private static readonly int _move = Animator.StringToHash(StaticEnemyParametrs.IsMove);
        private static readonly int _speedParametr = Animator.StringToHash(StaticEnemyParametrs.MoveParametr);

        public void PlayMove(float speed)
        {
            AnimationMoveOn();
            SetMoveAnimationSpeed(speed);
        }

        public void StopPlayMove() => _animator.SetBool(_move, false);

        public void PlayAttack() => _animator.SetTrigger(_attack);

        private void AnimationMoveOn() => _animator.SetBool(_move, true);
        private void SetMoveAnimationSpeed(float speed) => _animator.SetFloat(_speedParametr, GetNormalizeMoveSpeed(speed));
        private float GetNormalizeMoveSpeed(float speed) => speed / _baseAnimationMoveSpeed;
    }
}