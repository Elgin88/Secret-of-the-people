﻿using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Animator _animator;

        private readonly int _attack = Animator.StringToHash(StaticEnemy.IsAttack);
        private readonly int _move = Animator.StringToHash(StaticEnemy.IsMove);
        private readonly int _speedParametr = Animator.StringToHash(StaticEnemy.MoveParametr);
        private float _baseAnimationMoveSpeed;

        private void Awake()
        {
            _baseAnimationMoveSpeed = _staticData.AnimationBaseMoveSpeed;
        }

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
        private float GetNormalizeMoveSpeed(float currentMoveSpeed) => currentMoveSpeed / _baseAnimationMoveSpeed;
    }

}