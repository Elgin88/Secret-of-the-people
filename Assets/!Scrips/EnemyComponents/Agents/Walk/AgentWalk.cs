using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    public class AgentWalk : MonoBehaviour, IAgent
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyAnimator _enemyAnimator;

        private const float _speed = 5;
        private const int _minRange = -10;
        private const int _maxRange = 10;
        private const int _minDistanceToTarget = 2;
        private Vector3 _targetPosition;

        public void EnableAgent()
        {
            SetEnable();
            IsMoveInNavMesh();
            SetSpeedInNavMesh(_speed);
            SetTargetPosition();
            PlayAnimationMove(_speed);
        }
        
        public void DisableAgent()
        {
            IsStopInNavMesh();
            StopAnimationMove();
            SetDisable();
        }

        private void Start() => EnableAgent();

        private void Update()
        {
            Debug.Log(_navMeshAgent.speed);
            TrySetNextPosition();
            Move();
        }
        
        private void TrySetNextPosition()
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
        private void SetEnable() => enabled = true;
        private void SetDisable() => enabled = false;
        private bool IsMinDistance() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToTarget;
        private void Move() => _navMeshAgent.destination = _targetPosition;
        private void IsMoveInNavMesh() => _navMeshAgent.isStopped = false;
        private void IsStopInNavMesh() => _navMeshAgent.isStopped = true;
        private void SetSpeedInNavMesh(float walkSpeed) => _navMeshAgent.speed = walkSpeed;
        private void PlayAnimationMove(float walkSpeed) => _enemyAnimator.PlayMove(walkSpeed);
        private void StopAnimationMove() => _enemyAnimator.StopPlayMove();
    }
}