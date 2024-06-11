using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AgentMoveToPlayer))]

    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int _attack = Animator.StringToHash("IsAttack");
        private static readonly int _move = Animator.StringToHash("IsMove");
        private static readonly int _speedParametr = Animator.StringToHash("IsMoveParametr");
        private Animator _animator;
        private AgentMoveToPlayer _agentMoveToPlayer;

        public void PlayMove()
        {
            _animator.SetFloat(_speedParametr, _agentMoveToPlayer.NormalizeSpeed);
            _animator.SetBool(_move, true);
        }

        public void StopPlayMove()
        {
            _animator.SetBool(_move, false);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(_attack);
        }

        private void GetComponents()
        {
            _animator = GetComponent<Animator>();
            _agentMoveToPlayer = GetComponent<AgentMoveToPlayer>();
        }

        private void Awake()
        {
            GetComponents();
        }
    }
}