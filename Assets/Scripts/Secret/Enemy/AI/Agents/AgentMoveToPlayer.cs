﻿using Secret.Enemy.Animations;
using Secret.Enemy.Logic;
using Secret.Infrastructure.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace Secret.Enemy.AI.Agents
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _animationsSetter;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

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
            PlayAnimationRun();
            MoveToPlayer();
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

        private void PlayAnimationRun() => _animationsSetter.PlayRun();

        private void MoveToPlayer()
        {
            NavMeshOn();
            SetNavMeshRunSpeed();
            _navMeshAgent.destination = _gameFactory.Player.transform.position;
        }

        private void SetNavMeshRunSpeed()
        {
            _speedSetter.SetRunSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
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