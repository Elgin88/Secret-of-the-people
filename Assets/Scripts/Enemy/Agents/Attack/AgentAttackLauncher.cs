using System;
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
        [SerializeField] private AgentMoveToPlayerLauncher _moveToPlayerLauncher;
        [SerializeField] private AgentAttackTargetFinder _attackTargetFinder;
        [SerializeField] private AgentPatrolLauncher _patrolLauncher;
        [SerializeField] private AgentAttack _agentAttack;

        private void Awake() => _attackTargetFinder.TargetIsFound += AgentOn;

        private void OnDestroy() => _attackTargetFinder.TargetIsFound -= AgentOn;

        private void Update()
        {
            Debug.Log("1");
        }

        public void AgentOn()
        {
            _moveToPlayerLauncher.AgentOff();
            _patrolLauncher.AgentOff();

            _agentAttack.EnableAgent();
        }

        public void AgentOff() => _agentAttack.DisableAgent();
    }
}