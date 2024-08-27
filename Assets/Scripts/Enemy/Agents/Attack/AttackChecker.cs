using Scripts.Enemy;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AgentAttack))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    public class AttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AttackZone _attackZone;

        private void Awake()
        {
            _attackZone.PlayerEnter += OnPlayerEnter;
            _attackZone.PlayerExit += OnPlayerExit;
        }

        private void OnDestroy()
        {
            _attackZone.PlayerExit -= OnPlayerExit;
            _attackZone.PlayerEnter -= OnPlayerEnter;
        }

        private void OnPlayerEnter(Collider player)
        {
            DisableAgentMove();
            EnableAgentAttack();
        }

        private void OnPlayerExit(Collider player)
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