using System.Collections;
using Secret.Enemy.Animations;
using Secret.Enemy.Logic;
using Secret.Enemy.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Secret.Enemy.AI.Agents
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
        private const float _maxRayDistance = 1;
        private const int _maxPatrolRange = 10;
        private const int _minPatrolRange = -10;
        private float AttackRange => _staticData.AttackRange;

        private void OnEnable() => NavMeshOn();

        private void OnDisable() => NavMeshOff();

        private void FixedUpdate()
        {
            if (IsMinDistance() || IsNotTargetPosition())
            {
                FindTargetPosition();
            }

            PlayPatrolAnimation();
            MoveToTargetPosition();
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
        private bool IsOnGround() => Physics.RaycastNonAlloc(transform.position, Vector3.down, _results, _maxRayDistance, _groundMask) > 0;
        private bool IsMinDistance() => Vector3.Distance(_position, _targetPosition) < AttackRange;
        private void PlayPatrolAnimation() => _animationSetter.PlayRun();
        private void SetTargetPosition() => _targetPosition = new Vector3(_position.x + GetRandomValue(), _position.y, _position.z + GetRandomValue());
        private void FindTargetPosition() => StartCoroutine(StartFindTargetPosition());
        private int GetRandomValue() => Random.Range(_minPatrolRange, _maxPatrolRange);

        private void MoveToTargetPosition()
        {
            SetPatrolSpeed();
            NavMeshOn();
            _navMeshAgent.destination = _targetPosition;
        }

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