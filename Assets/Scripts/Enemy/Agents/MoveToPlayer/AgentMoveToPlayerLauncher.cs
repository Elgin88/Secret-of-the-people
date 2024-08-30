using Enemy.Agents.Patrol;
using UnityEngine;

namespace Enemy.Agents.MoveToPlayer
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class AgentMoveToPlayerLauncher : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private AgroZone _agroZone;

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

        private void AgentOn(Collider player)
        {
            DisableAgentPatrol();
            EnableAgentMove();
        }

        private void AgentOff(Collider player)
        {
            DisableAgentMove();
            EnableAgentPatrol();
        }

        private void SubPlayerExit() => _agroZone.Exit += AgentOff;
        private void SubPlayerEnter() => _agroZone.Enter += AgentOn;
        private void UnsubPlayerExit() => _agroZone.Exit -= AgentOff;
        private void UnsubPlayerEnter() => _agroZone.Enter -= AgentOn;
        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();
        private void EnableAgentPatrol() => _agentPatrol.EnableAgent();
        private void DisableAgentPatrol() => _agentPatrol.DisableAgent();
    }
}
