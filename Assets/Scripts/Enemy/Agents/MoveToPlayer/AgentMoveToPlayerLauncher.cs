using Enemy.Agents.Attack;
using Enemy.Agents.Patrol;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.Agents.MoveToPlayer
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class AgentMoveToPlayerLauncher : MonoBehaviour
    {
        private AgentAttackTargetFinder _targetChecker;
        private AgentMoveToPlayer _agentMoveToPlayer;
        private AgentPatrol _agentPatrol;
        private AgroSetter _agroSetter;

        private void Awake()
        {
            _targetChecker = GetComponent<AgentAttackTargetFinder>();
            _agentMoveToPlayer = GetComponent<AgentMoveToPlayer>();
            _agentPatrol = GetComponent<AgentPatrol>();
            _agroSetter = GetComponent<AgroSetter>();
            
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
        private void SubPlayerExit() => _agroSetter.Exit += AgentOff;
        private void SubPlayerEnter() => _agroSetter.Enter += AgentOn;
        private void UnsubPlayerExit() => _agroSetter.Exit -= AgentOff;
        private void UnsubPlayerEnter() => _agroSetter.Enter -= AgentOn;
        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();
        private void EnableAgentPatrol() => _agentPatrol.AgentEnable();
        private void DisableAgentPatrol() => _agentPatrol.AgentDisable();
    }
}