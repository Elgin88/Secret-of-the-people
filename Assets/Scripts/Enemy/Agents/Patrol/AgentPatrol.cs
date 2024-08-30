﻿using System.Collections;
using Enemy.Animations;
using Enemy.Logic;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Agents.Patrol
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(AgentPatrolLauncher))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SpeedSetter))]

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
        private int _maxRange => _staticData.MaxPatrolRange;
        private int _minRange => _staticData.MinPatrolRange;
        private int _minDistanceToPlayer => _staticData.MinDistanceToPlayer;

        public void AgentEnable()
        {
            Enabled(true);
            IsMoveNavMesh(true);
            SetPatrolSpeed();
            FindPosition();
            PlayAnimation();
        }

        public void AgentDisable()
        {
            StopAnimation();
            IsMoveNavMesh(false);
            Enabled(false);
        }

        private void FixedUpdate()
        {
            MoveNavMesh();

            if (IsMinDistance())
            {
                StartCoroutine(FindPosition());
            }
        }

        private void IsMoveNavMesh(bool status) => _navMeshAgent.isStopped = !status;
        private bool IsOnGround() => Physics.Raycast(_targetPosition, Vector3.down, _rayLength, _groundMask);
        private int GetRandom() => Random.Range(_minRange, _maxRange);
        private bool IsMinDistance() => Vector3.Distance(transform.position, _targetPosition) < _minDistanceToPlayer;
        private void Enabled(bool status) => enabled = status;
        private void MoveNavMesh() => _navMeshAgent.destination = _targetPosition;
        private void PlayAnimation() => _animationSetter.PlayRun();
        private void StopAnimation() => _animationSetter.StopPlayRun();
        private void SetTargetPosition() => _targetPosition = new Vector3(_position.x + GetRandom(), _position.y, _position.z + GetRandom());

        private void SetPatrolSpeed()
        {
            _speedSetter.SetPatrolSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }

        private IEnumerator FindPosition()
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