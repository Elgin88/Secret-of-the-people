using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgroZone _agroZone;
        [SerializeField] private AgentPatrol _agentPatrol;

        private void Awake()
        {
            _agroZone.TriggeredEnter += OnPlayerEnter;
            _agroZone.TriggeredExit += OnPlayerExit;
        }

        private void OnDisable()
        {
            _agroZone.TriggeredEnter -= OnPlayerEnter;
            _agroZone.TriggeredExit -= OnPlayerExit;
        }

        private void OnPlayerEnter(Collider collider)
        {
            DisableAgentPatrol();
            EnableAgentMove();
        }

        private void OnPlayerExit(Collider collider)
        {
            DisableAgentMove();
            EnableAgentPatrol();
        }

        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();

        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();

        private void EnableAgentPatrol() => _agentPatrol.EnableAgent();

        private void DisableAgentPatrol() => _agentPatrol.DisableAgent();
    }
}