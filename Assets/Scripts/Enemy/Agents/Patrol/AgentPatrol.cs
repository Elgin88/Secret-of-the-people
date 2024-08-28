using System.Collections;
using Enemy.Animations;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Agents.Patrol
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SpeedSetter))]

    public class AgentPatrol : MonoBehaviour, IEnemyAgent
    {
        [SerializeField] private EnemyAnimationsSetter _animationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;
        [SerializeField] private LayerMask _groundMask;

        private const int _rayLength = 2;
        private Vector3 _targetPosition;
        private Vector3 _position => transform.position;
        private float _patrolSpeed => _staticData.PatrolSpeed;
        private int _maxRange;
        private int _minRange;
        private int _minDistanceToPlayer;

        private void Awake() => SetParametrs();

        private void Start() => EnableAgent();

        private void FixedUpdate()
        {
            MoveNavMesh();
            PlayAnimation();

            if (IsMinDistanceToTarget())
            {
                StartCoroutine(SetTargetPosition());
            }
        }

        public void EnableAgent()
        {
            Enable();
            SetIsMoved();
            SetSpeed();
            SetTargetPosition();
        }

        public void DisableAgent()
        {
            SetIsStoped();
            StopAnimation();
            Disable();
        }

        private bool TargetIsOnGround() => Physics.Raycast(_targetPosition, Vector3.down, _rayLength, _groundMask);

        private int GetRandom() => Random.Range(_minRange, _maxRange);

        private bool IsMinDistanceToTarget() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToPlayer;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void MoveNavMesh() => _navMeshAgent.destination = _targetPosition;

        private void SetIsMoved() => _navMeshAgent.isStopped = false;

        private void SetIsStoped() => _navMeshAgent.isStopped = true;

        private void SetSpeed() => _navMeshAgent.speed = _patrolSpeed;

        private void PlayAnimation() => _animationSetter.PlayRun();

        private void StopAnimation() => _animationSetter.StopPlayRun();

        private void SetParametrs()
        {
            _minDistanceToPlayer = _staticData.MinDistanceToPlayer;
            _maxRange = _staticData.MaxPatrolRange;
            _minRange = _staticData.MinPatrolRange;
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
            float deltaX = GetRandom();
            float deltaZ = GetRandom();

            _targetPosition = new Vector3(_position.x + deltaX, _position.y, _position.z + deltaZ);
        }
    }
}