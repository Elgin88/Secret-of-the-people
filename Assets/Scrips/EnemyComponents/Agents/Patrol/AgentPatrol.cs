using Scripts.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    public class AgentPatrol : MonoBehaviour, IAgent
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private MonsterStaticData _staticData;

        private float _patrolSpeed;
        private int _maxPatrolRange;
        private int _minPatrolRange;
        private int _minDistanceToPlayer;
        private Vector3 _targetPosition;

        private void Awake()
        {
            _patrolSpeed = _staticData.PatrolSpeed;
            _maxPatrolRange = _staticData.MaxPatrolRange;
            _minPatrolRange = _staticData.MinPatrolRange;
            _minDistanceToPlayer = _staticData.MinDistanceToPlayer;
        }

        public void EnableAgent()
        {
            Enable();
            SetIsMovedInNavMesh();
            SetMaxSpeedInNavMesh(_patrolSpeed);
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

        private int GetRandomDelta() => Random.Range(_minPatrolRange, _maxPatrolRange);

        private bool IsMinDistanceToTarget() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToPlayer;

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