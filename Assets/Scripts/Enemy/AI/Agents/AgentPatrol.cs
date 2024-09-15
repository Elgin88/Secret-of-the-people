using System.Collections;
using Enemy.Animations;
using Enemy.Logic;
using StaticData;
using Unity.VisualScripting;
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

        private Vector3 _targetPosition;
        private Vector3 _position => transform.position;
        private int _maxRange => _staticData.MaxPatrolRange;
        private int _minRange => _staticData.MinPatrolRange;
        private int _minDistanceToPlayer => _staticData.MinDistanceToPlayer;
        private RaycastHit[] _results = new RaycastHit[5];
        private const float _length = 5;

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
            if (IsMinDistanceToPlayer() || IsNotTargetPosition())
            {
                FindPosition();
            }

            SetPatrolSpeed();
            PlayAnimation();
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
        private void PlayAnimation() => _animationSetter.PlayRun();
        private int GetRandomValue() => Random.Range(_minRange, _maxRange);
        private bool IsMinDistanceToPlayer() => Vector3.Distance(_position, _targetPosition) < _minDistanceToPlayer;
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