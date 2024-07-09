using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    public class AgentPatrol : MonoBehaviour, IAgent
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyAnimator _enemyAnimator;

        private const float _maxSpeed = 1.5f;
        private const int _minRange = -10;
        private const int _maxRange = 10;
        private const int _minDistanceToTarget = 2;
        private Vector3 _targetPosition;

        public void EnableAgent()
        {
            Enable();
            SetIsMovedInNavMesh();
            SetMaxSpeedInNavMesh(_maxSpeed);
            SetTargetPosition();
        }

        public void DisableAgent()
        {
            SetIsStopedInNavMesh();
            StopAnimationOfMove();
            Disable();
        }

        private void Start() => EnableAgent();

        private void Update()
        {
            Move();
            PlayAnimationMove(CurrentSpeed());
            TryChangeTargetPosition();
        }

        private void TryChangeTargetPosition()
        {
            if (IsMinDistanceToTarget())
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

        private float CurrentSpeed() => _navMeshAgent.speed;
        private int GetRandomDelta() => Random.Range(_minRange, _maxRange);
        private bool IsMinDistanceToTarget() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToTarget;
        private void Enable() => enabled = true;
        private void Disable() => enabled = false;
        private void Move() => _navMeshAgent.destination = _targetPosition;
        private void SetIsMovedInNavMesh() => _navMeshAgent.isStopped = false;
        private void SetIsStopedInNavMesh() => _navMeshAgent.isStopped = true;
        private void SetMaxSpeedInNavMesh(float speed) => _navMeshAgent.speed = speed;
        private void PlayAnimationMove(float speed) => _enemyAnimator.PlayMove(speed);
        private void StopAnimationOfMove() => _enemyAnimator.StopPlayMove();
    }
}