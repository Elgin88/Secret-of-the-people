using System.Collections;
using Enemy.Animations;
using Enemy.Logic;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Agents.Patrol
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(NavMeshAgent))]

    public partial class AgentPatrol : MonoBehaviour
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
        private int _maxRange => _staticData.MaxPatrolRange;
        private int _minRange => _staticData.MinPatrolRange;
        private int _minDistanceToPlayer => _staticData.MinDistanceToPlayer;

        private void Start() => EnableAgent();

        private void FixedUpdate()
        {
            MoveNavMesh();
            PlayAnimation();

            if (IsMinDistance())
            {
                StartCoroutine(FindTargetPosition());
            }
        }

        public void EnableAgent()
        {
            SetSpeed();
            SetEnabled(true);
            SetNavMeshEnabled(true);
            FindTargetPosition();
        }

        public void DisableAgent()
        {
            StopAnimation();
            SetNavMeshEnabled(false);
            SetEnabled(false);
        }

        private void SetNavMeshEnabled(bool status) => _navMeshAgent.isStopped = !status;
        private bool IsOnGround() => Physics.Raycast(_targetPosition, Vector3.down, _rayLength, _groundMask);
        private int GetRandom() => Random.Range(_minRange, _maxRange);
        private bool IsMinDistance() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToPlayer;
        private void SetEnabled(bool status) => enabled = status;
        private void MoveNavMesh() => _navMeshAgent.destination = _targetPosition;
        private void PlayAnimation() => _animationSetter.PlayRun();
        private void StopAnimation() => _animationSetter.StopPlayRun();
        private void SetRandomTargetPosition() => _targetPosition = new Vector3(_position.x + GetRandom(), _position.y, _position.z + GetRandom());

        private void SetSpeed()
        {
            _speedSetter.SetPatrolSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }

        private IEnumerator FindTargetPosition()
        {
            SetRandomTargetPosition();

            while (!IsOnGround())
            {
                SetRandomTargetPosition();

                yield return null;
            }
        }
    }
}