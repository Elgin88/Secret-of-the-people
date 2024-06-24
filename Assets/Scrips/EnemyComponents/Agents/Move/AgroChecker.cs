using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroChecker : MonoBehaviour
    {
        [SerializeField] private AgroZone _agroTrigger;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void Awake()
        {
            DisableAgentMove();

            _agroTrigger.TriggeredEnter += OnPlayerEnter;
            _agroTrigger.TriggeredExit += OnPlayerExit;
        }

        private void OnDisable()
        {
            _agroTrigger.TriggeredEnter -= OnPlayerEnter;
            _agroTrigger.TriggeredExit -= OnPlayerExit;
        }

        private void OnPlayerEnter(Collider collider) => EnableAgentMove();
        private void OnPlayerExit(Collider collider) => DisableAgentMove();
        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();
    }
}