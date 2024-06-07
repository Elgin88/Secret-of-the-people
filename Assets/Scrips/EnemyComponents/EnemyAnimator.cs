using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AgentMoveToPlayer))]

    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int _move = Animator.StringToHash("IsMove");
        private static readonly int _speedParametr = Animator.StringToHash("SpeedParametr");
        private Animator _animator;
        private AgentMoveToPlayer _agentMoveToPlayer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _agentMoveToPlayer = GetComponent<AgentMoveToPlayer>();
        }

        public void PlayMove()
        {
            _animator.SetFloat(_speedParametr, _agentMoveToPlayer.NormalizeSpeed);
            _animator.SetBool(_move, true);
        }

        public void StopPlayMove() => _animator.SetBool(_move, false);
    }
}