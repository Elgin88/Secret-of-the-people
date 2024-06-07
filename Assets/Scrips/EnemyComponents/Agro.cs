using System;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(NavMeshAgent))]

    public class Agro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private AgentMoveToPlayer _agentMoveToPlayer;
        private EnemyAnimator _enemyAnimator;
        private NavMeshAgent _navMeshAgent;

        private void OnEnable()
        {
            _agentMoveToPlayer = GetComponent<AgentMoveToPlayer>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _triggerObserver.TriggeredEnter += TriggerEnter;
            _triggerObserver.TriggeredExit += TriggerExit;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggeredEnter -= TriggerEnter;
            _triggerObserver.TriggeredExit -= TriggerExit;
        }

        private void TriggerEnter(Collider collider)
        {
            AgentMoverOn();
            _navMeshAgent.isStopped = false;
        }

        private void TriggerExit(Collider collider)
        {
            _agentMoveToPlayer.enabled = false;
            _enemyAnimator.StopPlayMove();
            _navMeshAgent.isStopped = true;
        }

        private void AgentMoverOn() => AgentMoverOff();
        private void AgentMoverOff() => _agentMoveToPlayer.enabled = true;
    }
}