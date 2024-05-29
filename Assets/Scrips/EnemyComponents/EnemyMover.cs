using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]

    public class EnemyMover : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private EnemyAnimator _enemyAnimator;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
        }

        private void Update()
        {
            if (_navMeshAgent.isStopped)
            {
                _enemyAnimator.PlayMove();
            }
            else
            {
                _enemyAnimator.StopPlayMove();
            }
        }
    }
}