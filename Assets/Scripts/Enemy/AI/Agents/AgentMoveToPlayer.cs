using Enemy.AI.Agents.Starters;
using Enemy.AI.Agents.Stoppers;
using Enemy.Animations;
using Enemy.Logic;
using Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.AI.Agents
{
    [RequireComponent(typeof(StarterAgentMoveToPlayer))]
    [RequireComponent(typeof(StopperAgentMoveToPlayer))]
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _animationsSetter;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void OnEnable()
        {
            PlayAnimation();
        }

        private void OnDisable()
        {
            StopPlayAnimation();
        }

        private void FixedUpdate()
        {
            SetNavMeshRunSpeed();
            PlayAnimation();
            MoveToPlayer();
        }

        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);
            }
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