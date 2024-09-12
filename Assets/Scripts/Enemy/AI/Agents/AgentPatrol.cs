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

        private const int _rayLength = 1;
        private Vector3 _targetPosition;
        private Vector3 _position => transform.position;
        private int _maxRange => _staticData.MaxPatrolRange;
        private int _minRange => _staticData.MinPatrolRange;
        private int _minDistanceToPlayer => _staticData.MinDistanceToPlayer;

        private void FixedUpdate()
        {
            if (IsMinDistance() || IsNotTargetPosition())
            {
                FindPosition();
            }

            SetPatrolSpeed();
            PlayAnimation();
            Move();
        }

        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);

                Debug.Log("PatrolStart");
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);

                Debug.Log("PatrolStop");
            }
        }

        private bool IsNotTargetPosition() => _targetPosition == null;
        private void PlayAnimation() => _animationSetter.PlayRun();
        private bool IsOnGround() => Physics.Raycast(_targetPosition, Vector3.down, _rayLength, _groundMask);
        private int GetRandomValue() => Random.Range(_minRange, _maxRange);
        private bool IsMinDistance() => Vector3.Distance(_position, _targetPosition) < _minDistanceToPlayer;
        private void Move() => _navMeshAgent.destination = _targetPosition;
        private void SetTargetPosition() => _targetPosition = new Vector3(_position.x + GetRandomValue(), _position.y, _position.z + GetRandomValue());
        private void FindPosition() => StartCoroutine(StartFindTargetPosition());
        private void SetEnabled(bool status) => enabled = status;

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
    }
}