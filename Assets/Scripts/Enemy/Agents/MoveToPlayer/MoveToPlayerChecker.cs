using Scripts.Enemy;
using UnityEngine;


namespace Enemy.Agents.MoveToPlayer
{
    public class MoveToPlayerChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private AgroZone _agroZone;

        private void Awake()
        {
            SubPlayerEnter();
            SubPlayerExit();
        }

        private void OnDisable()
        {
            UnsubPlayerEnter();
            UnsubPlayerExit();
        }

        private void OnPlayerEnter(Collider player)
        {
            DisableAgentPatrol();
            EnableAgentMove();
        }

        private void OnPlayerExit(Collider player)
        {
            DisableAgentMove();
            EnableAgentPatrol();
        }

        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();
        private void EnableAgentPatrol() => _agentPatrol.EnableAgent();
        private void DisableAgentPatrol() => _agentPatrol.DisableAgent();
        private void SubPlayerEnter() => _agroZone.TriggeredEnter += OnPlayerEnter;
        private void SubPlayerExit() => _agroZone.TriggeredExit += OnPlayerExit;
        private void UnsubPlayerExit() => _agroZone.TriggeredExit -= OnPlayerExit;
        private void UnsubPlayerEnter() => _agroZone.TriggeredEnter -= OnPlayerEnter;
    }
}
