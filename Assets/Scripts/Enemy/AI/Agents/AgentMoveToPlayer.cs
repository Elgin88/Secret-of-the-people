using Enemy.Animations;
using Enemy.Logic;
using Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.AI.Agents
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _animationsSetter;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpeedSetter _speedSetter;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void OnDisable()
        {
            PlayAnimationIdle();
        }

        private void FixedUpdate()
        {
            SetNavMeshRunSpeed();
            PlayAnimationRun();
            MoveToPlayer();
        }

        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);

                Debug.Log("MoveStart");
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);

                Debug.Log("MoveStop");
            }
        }

        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimationRun() => _animationsSetter.PlayRun();
        private void PlayAnimationIdle() => _animationsSetter.PlayIdle();
        private void MoveToPlayer() => _navMeshAgent.destination = _gameFactory.Player.transform.position;

        private void SetNavMeshRunSpeed()
        {
            _speedSetter.SetRunSpeed();
            _navMeshAgent.speed = _speedSetter.CurrentSpeed;
        }
    }
}