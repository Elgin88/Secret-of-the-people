using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgroZoneEnter _agroTriggerEnter;
        [SerializeField] private AgroZoneExit _agroTriggerExit;

        private void Awake()
        {
            DisableAgentMove();

            _agroTriggerEnter.TriggeredEnter += OnPlayerEnter;
            _agroTriggerExit.TriggeredExit += OnPlayerExit;
        }

        private void OnDisable()
        {
            _agroTriggerEnter.TriggeredEnter -= OnPlayerEnter;
            _agroTriggerExit.TriggeredExit -= OnPlayerExit;
        }

        private void OnPlayerEnter(Collider collider) => EnableAgentMove();
        private void OnPlayerExit(Collider collider) => DisableAgentMove();
        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();
    }
}