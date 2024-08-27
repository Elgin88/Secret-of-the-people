using System.Collections;
using Enemy.Animations;
using Scripts.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(AnimationSetter))]
    public class AgentPatrol : MonoBehaviour, IAgent
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private AnimationSetter _animationSetter;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private LayerMask _groundMask;

        private const int _rayLength = 5;
        private Vector3 _targetPosition;
        private float _patrolSpeed;
        private int _maxRange;
        private int _minRange;
        private int _minDistanceToPlayer;

        public float PatrolSpeed => _patrolSpeed;

        private void Awake() => SetParametrs();

        private void Start() => EnableAgent();

        private void FixedUpdate()
        {
            Move();
            PlayAnimationMove();

            if (IsMinDistanceToTarget())
            {
                StartCoroutine(SetTargetPosition());
            }
        }

        public void EnableAgent()
        {
            Enable();
            SetIsMovedInNavMesh();
            SetSpeedInNavMesh(_patrolSpeed);
            SetTargetPosition();
        }

        public void DisableAgent()
        {
            SetIsStopedInNavMesh();
            StopAnimationOfMove();
            Disable();
        }

        private void SetParametrs()
        {
            _patrolSpeed = _staticData.PatrolSpeed;
            _maxRange = _staticData.MaxPatrolRange;
            _minRange = _staticData.MinPatrolRange;
            _minDistanceToPlayer = _staticData.MinDistanceToPlayer;
        }

        private IEnumerator SetTargetPosition()
        {
            SetRandomTargetPosition();

            while (!TargetIsOnGround())
            {
                SetRandomTargetPosition();

                yield return null;
            }
        }

        private void SetRandomTargetPosition()
        {
            float deltaX = GetRandomDelta();
            float deltaZ = GetRandomDelta();

            _targetPosition = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + deltaZ);
        }

        private bool TargetIsOnGround() => Physics.Raycast(_targetPosition, Vector3.down, _rayLength, _groundMask);

        private int GetRandomDelta() => Random.Range(_minRange, _maxRange);

        private bool IsMinDistanceToTarget() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToPlayer;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void Move() => _navMeshAgent.destination = _targetPosition;

        private void SetIsMovedInNavMesh() => _navMeshAgent.isStopped = false;

        private void SetIsStopedInNavMesh() => _navMeshAgent.isStopped = true;

        private void SetSpeedInNavMesh(float speed) => _navMeshAgent.speed = speed;

        private void PlayAnimationMove() => _animationSetter.PlayRun();

        private void StopAnimationOfMove() => _animationSetter.StopPlayRun();
    }
}