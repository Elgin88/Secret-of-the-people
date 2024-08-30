using Enemy.Agents.Attack;
using Enemy.Agents.Patrol;
using UnityEngine;

namespace Enemy.Agents.MoveToPlayer
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class AgentMoveToPlayerLauncher : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgentAttackTargetFinder _targetChecker;
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private AgroSetter _agroZone;

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

        public void AgentOn()
        {
            DisableAgentPatrol();
            EnableAgentMove();
            EnableTargetChecker();
        }

        public void AgentOff()
        {
            DisableAgentMove();
            EnableAgentPatrol();
            DisableTargetChecker();
        }

        private void EnableTargetChecker() => _targetChecker.Enable();
        private void DisableTargetChecker() => _targetChecker.Disable();
        private void SubPlayerExit() => _agroZone.Exit += AgentOff;
        private void SubPlayerEnter() => _agroZone.Enter += AgentOn;
        private void UnsubPlayerExit() => _agroZone.Exit -= AgentOff;
        private void UnsubPlayerEnter() => _agroZone.Enter -= AgentOn;
        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();
        private void EnableAgentPatrol() => _agentPatrol.AgentEnable();
        private void DisableAgentPatrol() => _agentPatrol.AgentDisable();
    }
}