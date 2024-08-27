using Scripts.Enemy;
using UnityEngine;


namespace Enemy.Agents.MoveToPlayer
{
    [RequireComponent(typeof(AgroZone))]
    [RequireComponent(typeof(AgentPatrol))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    public class MoveToPlayerChecker : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private AgroZone _agroZone;

        private void Awake()
        {
            _agroZone.Enter += OnPlayerEnter;
            _agroZone.Exit += OnPlayerExit;
        }

        private void OnDisable()
        {
            _agroZone.Enter -= OnPlayerEnter;
            _agroZone.Exit -= OnPlayerExit;
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
    }
}
