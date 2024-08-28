using Enemy.Animations;
using Enemy.Logic;
using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Agents.MoveToPlayer
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(NavMeshAgent))]

    public class AgentMoveToPlayer : MonoBehaviour, IEnemyAgent
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;

        private IGameFactory _gameFactory;
        private Transform _playerTransform;

        private void Start()
        {
            SetComponents();
            Disable();
        }

        private void FixedUpdate() => MoveToTarget();

        public void Construct(IGameFactory iGameFactory) => _gameFactory = iGameFactory;

        public void EnableAgent()
        {
            Enable();
            NavMeshMoveOn();
            SetNavMeshRunSpeed();
            PlayAnimation();
        }

        public void DisableAgent()
        {
            NavMeshMoveOff();
            StopPlayAnimationRun();
            Disable();
        }

        private void NavMeshMoveOn() => _navMeshAgent.isStopped = false;

        private void NavMeshMoveOff() => _navMeshAgent.isStopped = true;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void PlayAnimation() => _enemyAnimator.PlayRun();

        private void StopPlayAnimationRun() => _enemyAnimator.StopPlayRun();

        private void MoveToTarget() => _navMeshAgent.destination = _playerTransform.position;

        private void SetNavMeshRunSpeed()
        {
            _speedSetter.SetRunSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }

        private void SetComponents()
        {
            _enemyAnimator = GetComponent<EnemyAnimationsSetter>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _playerTransform = _gameFactory.Player.transform;
        }
    }
}