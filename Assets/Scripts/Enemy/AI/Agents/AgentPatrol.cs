using System.Collections;
using Enemy.Animations;
using Enemy.Logic;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.AI.Agents
{
    public class AgentPatrol : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _animationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;
        [SerializeField] private LayerMask _groundMask;

        private RaycastHit[] _results = new RaycastHit[5];
        private Vector3 _targetPosition;
        private Vector3 _position => transform.position;
        private const float _length = 2;
        private const int _maxPatrolRange = 10;
        private const int _minPatrolRange = -10;
        private float AttackRange => _staticData.AttackRange;

        private void OnEnable()
        {
            NavMeshOn();
        }

        private void OnDisable()
        {
            NavMeshOff();
        }

        private void FixedUpdate()
        {
            Debug.Log("AgentPatrol");
            if (IsMinDistanceToPlayer() || IsNotTargetPosition())
            {
                FindPosition();
            }

            SetPatrolSpeed();
            PlayPatrolAnimation();
            NavMeshOn();
            NavMeshMove();
        }

        public void On()
        {
            if (!enabled)
            {
                enabled = true;
            }
        }

        public void Off()
        {
            if (enabled)
            {
                enabled = false;
            }
        }

        private bool IsNotTargetPosition() => _targetPosition == null;

        private void PlayPatrolAnimation() => _animationSetter.PlayRun();

        private int GetRandomValue() => Random.Range(_minPatrolRange, _maxPatrolRange);

        private bool IsMinDistanceToPlayer() => Vector3.Distance(_position, _targetPosition) < AttackRange;

        private void NavMeshMove() => _navMeshAgent.destination = _targetPosition;

        private void SetTargetPosition() => _targetPosition = new Vector3(_position.x + GetRandomValue(), _position.y, _position.z + GetRandomValue());

        private void FindPosition() => StartCoroutine(StartFindTargetPosition());

        private bool IsOnGround() => Physics.RaycastNonAlloc(transform.position, Vector3.down, _results, _length, _groundMask) > 0;

        private void SetPatrolSpeed()
        {
            _speedSetter.SetPatrolSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }

        private IEnumerator StartFindTargetPosition()
        {
            SetTargetPosition();

            while (!IsOnGround())
            {
                SetTargetPosition();

                yield return null;
            }
        }

        private void NavMeshOn()
        {
            if (_navMeshAgent.isOnNavMesh)
            {
                _navMeshAgent.isStopped = false;
            }
        }

        private void NavMeshOff()
        {
            if (_navMeshAgent.isOnNavMesh)
            {
                _navMeshAgent.isStopped = true;
            }
        }
    }
}