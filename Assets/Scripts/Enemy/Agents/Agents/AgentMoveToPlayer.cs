using Enemy.Agents.AgentsCheckers;
using Enemy.Agents.AgentsLaunchers;
using Enemy.Animations;
using Enemy.Logic;
using Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Agents.Agents
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SpeedSetter))]

    public class AgentMoveToPlayer : MonoBehaviour
    {
        private EnemyAnimationsSetter _animationsSetter;
        private NavMeshAgent _navMeshAgent;
        private SpeedSetter _speedSetter;
        
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory iGameFactory) => _gameFactory = iGameFactory;

        private void Awake() => GetComponents();

        private void Start()
        {
            Off();
        }

        private void FixedUpdate()
        {
            MoveToTarget();
        }

        public void On()
        {
            SetEnabled(true);
            SetNavMesnEnabled(true);
            SetNavMeshRunSpeed();
            PlayAnimation();
        }

        public void Off()
        {
            SetEnabled(false);
            SetNavMesnEnabled(true);
            StopPlayAnimation();
        }

        private void SetNavMesnEnabled(bool status) => _navMeshAgent.isStopped = !status;
        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimation() => _animationsSetter.PlayRun();
        private void StopPlayAnimation() => _animationsSetter.StopPlayRun();
        private void MoveToTarget() => _navMeshAgent.destination = _gameFactory.Player.transform.position;

        private void GetComponents()
        {
            _animationsSetter = GetComponent<EnemyAnimationsSetter>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _speedSetter = GetComponent<SpeedSetter>();
        }

        private void SetNavMeshRunSpeed()
        {
            _speedSetter.SetRunSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }
    }
}