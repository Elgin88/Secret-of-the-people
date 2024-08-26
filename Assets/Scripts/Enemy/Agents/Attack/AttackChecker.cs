using Scripts.Enemy;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class AttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AttackZone _attackZone;

        private void Awake()
        {
            _attackZone.IsPlayerEnter += OnPlayerEnter;
            _attackZone.IsPlayerExit += OnPlayerExit;
        }

        private void OnDestroy()
        {
            _attackZone.IsPlayerExit -= OnPlayerExit;
            _attackZone.IsPlayerEnter -= OnPlayerEnter;
        }

        private void OnPlayerEnter(Collider player)
        {
            DisableAgentMove();
            EnableAgentAttack();
        }

        private void OnPlayerExit(Collider collider)
        {
            DisableAgentAttack();
            EnableAgentMove();
        }

        private void EnableAgentAttack() => _agentAttack.EnableAgent();

        private void DisableAgentAttack() => _agentAttack.DisableAgent();

        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();

        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
    }
}