using Enemy.Animations;
using Enemy.Logic;
using Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Agents.MoveToPlayer
{
    [RequireComponent(typeof(AgentMoveToPlayerLauncher))]
    [RequireComponent(typeof(AgroSetter))]
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(NavMeshAgent))]

    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _animationsSetter;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;

        private IGameFactory _gameFactory;
        private Transform _target => _gameFactory.Player.transform;

        public void Construct(IGameFactory iGameFactory) => _gameFactory = iGameFactory;

        private void Start() => DisableAgent();

        private void FixedUpdate() => MoveToTarget();

        public void EnableAgent()
        {
            SetEnabled(true);
            SetNavMesnEnabled(true);
            SetNavMeshRunSpeed();
            PlayAnimation();
        }

        public void DisableAgent()
        {
            SetEnabled(false);
            SetNavMesnEnabled(false);
            StopPlayAnimation();
        }

        private void SetNavMesnEnabled(bool status) => _navMeshAgent.isStopped = !status;
        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimation() => _animationsSetter.PlayRun();
        private void StopPlayAnimation() => _animationsSetter.StopPlayRun();
        private void MoveToTarget() => _navMeshAgent.destination = _target.position;

        private void SetNavMeshRunSpeed()
        {
            _speedSetter.SetRunSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }
    }
}