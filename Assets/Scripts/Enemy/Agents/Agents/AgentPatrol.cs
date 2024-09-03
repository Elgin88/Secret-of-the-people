using System.Collections;
using Enemy.Agents.AgentsCheckers;
using Enemy.Animations;
using Enemy.Logic;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Agents.Agents
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SpeedSetter))]

    public class AgentPatrol : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _animationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;
        [SerializeField] private LayerMask _groundMask;

        private const int _rayLength = 1;
        private Vector3 _targetPosition;
        private Vector3 _position => transform.position;
        private int _maxRange => _staticData.MaxPatrolRange;
        private int _minRange => _staticData.MinPatrolRange;
        private int _minDistanceToPlayer => _staticData.MinDistanceToPlayer;

        private void OnEnable()
        {
            FindPosition();
            SetPatrolSpeed();
        }

        private void OnDisable()
        {
            StopAnimationRun();
        }
        
        public void On()
        {
            SetEnabled(true);
        }
        
        public void Off()
        {
            SetEnabled(false);
        }

        private void FixedUpdate()
        {
            Move();
            PlayAnimation();

            if (IsMinDistance())
            {
                FindPosition();
            }
        }

        private void PlayAnimation() => _animationSetter.PlayRun();
        private void StopAnimationRun() => _animationSetter.StopPlayRun();
        private bool IsOnGround() => Physics.Raycast(_targetPosition, Vector3.down, _rayLength, _groundMask);
        private int GetRandomValue() => Random.Range(_minRange, _maxRange);
        private bool IsMinDistance() => Vector3.Distance(_position, _targetPosition) < _minDistanceToPlayer;
        private void Move() => _navMeshAgent.destination = _targetPosition;
        private void SetTargetPosition() => _targetPosition = new Vector3(_position.x + GetRandomValue(), _position.y, _position.z + GetRandomValue());
        private void FindPosition() => StartCoroutine(SetPosition());
        private void SetEnabled(bool status) => enabled = status;

        private void SetPatrolSpeed()
        {
            _speedSetter.SetPatrolSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }

        private IEnumerator SetPosition()
        {
            SetTargetPosition();

            while (!IsOnGround())
            {
                SetTargetPosition();

                yield return null;
            }
        }
    }
}