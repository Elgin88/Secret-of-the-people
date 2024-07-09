using Scripts.Static;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const float _baseMoveSpeedForAnimation = 0.8f;
        private readonly int _attack = Animator.StringToHash(StaticEnemyParametrs.IsAttack);
        private readonly int _move = Animator.StringToHash(StaticEnemyParametrs.IsMove);
        private readonly int _speedParametr = Animator.StringToHash(StaticEnemyParametrs.MoveParametr);

        public void PlayMove(float speed)
        {
            SetMoveAnimationSpeed(speed);
            PlayAnimationMove();
        }

        public void StopPlayMove()
        {
            _animator.SetBool(_move, false);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(_attack);
        }

        private void PlayAnimationMove() => _animator.SetBool(_move, true);
        private void SetMoveAnimationSpeed(float currentSpeed) => _animator.SetFloat(_speedParametr, GetNormalizeMoveSpeed(currentSpeed));
        private float GetNormalizeMoveSpeed(float currentMoveSpeed) => currentMoveSpeed / _baseMoveSpeedForAnimation;
    }
}