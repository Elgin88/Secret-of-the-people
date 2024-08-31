using Enemy.Agents.MoveToPlayer;
using Enemy.Agents.Patrol;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AgentMoveToPlayerLauncher))]
    [RequireComponent(typeof(AgentAttackTargetFinder))]
    [RequireComponent(typeof(AgentAttack))]

    public class AgentAttackLauncher : MonoBehaviour
    {
        private AgentMoveToPlayerLauncher _moveToPlayerLauncher;
        private AgentAttackTargetFinder _attackTargetFinder;
        private AgentPatrolLauncher _patrolLauncher;
        private AgentAttack _agentAttack;

        private void Awake()
        {
            GetComponents();
            SubTargetFound();
        }

        private void OnDestroy() => OnsubTargetFound();

        public void AgentOn()
        {
            _moveToPlayerLauncher.AgentOff();
            _patrolLauncher.AgentOff();
            _agentAttack.EnableAgent();
        }

        public void AgentOff() => _agentAttack.DisableAgent();

        private void SubTargetFound() => _attackTargetFinder.TargetIsFound += AgentOn;
        private void OnsubTargetFound() => _attackTargetFinder.TargetIsFound -= AgentOn;

        private void GetComponents()
        {
            _moveToPlayerLauncher = GetComponent<AgentMoveToPlayerLauncher>();
            _attackTargetFinder = GetComponent<AgentAttackTargetFinder>();
            _patrolLauncher = GetComponent<AgentPatrolLauncher>();
            _agentAttack = GetComponent<AgentAttack>();
        }
    }
}