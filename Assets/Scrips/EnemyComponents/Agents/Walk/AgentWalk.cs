using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    public class AgentWalk : MonoBehaviour, IAgent
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyAnimator _enemyAnimator;

        private float _walkSpeed = 1;
        private const int _minRange = -10;
        private const int _maxRange = 10;
        private const int _minDistanceToTarget = 2;
        private Vector3 _targetPosition;

        public void EnableAgent()
        {
            Enable();
            NavMeshMove();
            SetTargetPosition();
            SetNavMeshSpeed();
            PlayAnimationMove();
        }

        public void DisableAgent()
        {
            Disable();
            NavMeshStop();
            StopAnimationMove();
        }

        private void Awake() => EnableAgent();
        private void Update() => Move();

        private void Move()
        {
            ChangePosition();
            TrySetTargetPosition();
        }

        private void TrySetTargetPosition()
        {
            if (IsMinDistance())
            {
                SetTargetPosition();
            }
        }

        private void SetTargetPosition()
        {
            float deltaX = GetRandomDelta();
            float deltaZ = GetRandomDelta();

            _targetPosition = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + deltaZ);
        }

        private int GetRandomDelta() => Random.Range(_minRange, _maxRange);
        private void Enable() => enabled = true;
        private void Disable() => enabled = false;
        private bool IsMinDistance() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToTarget;
        private void ChangePosition() => _navMeshAgent.destination = _targetPosition;
        private void NavMeshMove() => _navMeshAgent.isStopped = false;
        private void NavMeshStop() => _navMeshAgent.isStopped = true;
        private void SetNavMeshSpeed() => _navMeshAgent.speed = _walkSpeed;
        private void PlayAnimationMove() => _enemyAnimator.PlayMove(_walkSpeed);
        private void StopAnimationMove() => _enemyAnimator.StopPlayMove();
    }
}