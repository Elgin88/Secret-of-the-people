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
        [SerializeField] private EnemyAnimationsSetter _animationsSetter;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void OnEnable()
        {
            SetNavMeshRunSpeed();
        }

        private void OnDisable()
        {
            StopPlayAnimation();
        }

        private void FixedUpdate()
        {
            PlayAnimation();
            MoveToPlayer();
        }

        public void On()
        {
            SetEnabled(true);
        }

        public void Off()
        {
            SetEnabled(false);
        }

        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimation() => _animationsSetter.PlayRun();
        private void StopPlayAnimation() => _animationsSetter.StopPlayRun();
        private void MoveToPlayer() => _navMeshAgent.destination = _gameFactory.Player.transform.position;

        private void SetNavMeshRunSpeed()
        {
            _speedSetter.SetRunSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }
    }
}