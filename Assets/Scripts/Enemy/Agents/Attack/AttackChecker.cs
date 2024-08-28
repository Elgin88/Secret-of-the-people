using Enemy.Agents.MoveToPlayer;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentAttack))]

    public class AttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AttackZone _attackZone;

        private void Awake()
        {
            SubPlayerEnter();
            SubPlayerExit();
        }

        private void OnDestroy()
        {
            UnsubPlayerEnter();
            UnsubPlayerExit();
        }

        private void OnPlayerEnter(Collider player)
        {
            EnableAgentAttack();
            DisableAgentMove();
        }

        private void OnPlayerExit(Collider player)
        {
            EnableAgentMove();
        }

        private void DisableAgentAttack() => _agentAttack.DisableAgent();

        private void EnableAgentAttack() => _agentAttack.EnableAgent();

        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();

        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();

        private void SubPlayerExit() => _attackZone.PlayerExit += OnPlayerExit;

        private void SubPlayerEnter() => _attackZone.PlayerEnter += OnPlayerEnter;

        private void UnsubPlayerEnter() => _attackZone.PlayerEnter -= OnPlayerEnter;

        private void UnsubPlayerExit() => _attackZone.PlayerExit -= OnPlayerExit;
    }
}