using Enemy.Agents.Attack;
using Enemy.Agents.Patrol;
using UnityEngine;

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
            GetComponents();
        }

        private void FixedUpdate()
        {
            if (_agroSetter.IsAgro)
            {
                AgentOn();
            }
            else
            {
                AgentOff();
            }
        }

        private void EnableTargetChecker() => _targetChecker.Enable();
        private void DisableTargetChecker() => _targetChecker.Disable();
        private void EnableAgentMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableAgentMove() => _agentMoveToPlayer.DisableAgent();
        private void EnableAgentPatrol() => _agentPatrol.AgentEnable();
        private void DisableAgentPatrol() => _agentPatrol.AgentDisable();

        private void AgentOn()
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

        private void GetComponents()
        {
            _targetChecker = GetComponent<AgentAttackTargetFinder>();
            _agentMoveToPlayer = GetComponent<AgentMoveToPlayer>();
            _agentPatrol = GetComponent<AgentPatrol>();
            _agroSetter = GetComponent<AgroSetter>();
        }
    }
}