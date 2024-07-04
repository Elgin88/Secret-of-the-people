using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AttackZoneEnter _attackZoneEnter;
        [SerializeField] private AttackZoneExit _attackZoneExit;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void Awake()
        {
            _attackZoneEnter.IsPlayerEnter += OnPlayerEnter;
            _attackZoneExit.IsPlayerExit += OnPlayerExit;
        }

        private void OnDestroy()
        {
            _attackZoneExit.IsPlayerExit -= OnPlayerExit;
            _attackZoneEnter.IsPlayerEnter -= OnPlayerEnter;
        }

        private void OnPlayerEnter(Collider collider)
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