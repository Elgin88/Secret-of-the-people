using Enemy.Animations;
using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour, IAgent
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private AnimationSetter _enemyAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private IGameFactory _iGameFactory;
        private Transform _playerTransform;
        private float _moveToPlayerSpeed;

        public float MoveToPlayerSpeed => _moveToPlayerSpeed;

        private void Start()
        {
            SetComponents();
            Disable();
        }

        private void FixedUpdate() => MoveToTarget();

        public void Construct(IGameFactory iGameFactory)
        {
            _iGameFactory = iGameFactory;
        }

        public void EnableAgent()
        {
            Enable();
            SetMoveSpeed();
            NavMeshMoveOn();
            PlayAnimationRun();
        }

        public void DisableAgent()
        {
            NavMeshMoveOff();
            StopPlayAnimationRun();
            Disable();
        }

        private void SetComponents()
        {
            _enemyAnimator = GetComponent<AnimationSetter>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _moveToPlayerSpeed = _staticData.MoveToPlayerSpeed;
            _navMeshAgent.speed = _moveToPlayerSpeed;

            SetPlayerTransform();
        }

        private void SetPlayerTransform() => _playerTransform = _iGameFactory.Player.transform;

        private void NavMeshMoveOn() => _navMeshAgent.isStopped = false;

        private void NavMeshMoveOff() => _navMeshAgent.isStopped = true;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void PlayAnimationRun() => _enemyAnimator.PlayRun();

        private void StopPlayAnimationRun() => _enemyAnimator.StopPlayRun();

        private void MoveToTarget() => _navMeshAgent.destination = _playerTransform.position;

        private void SetMoveSpeed() => _navMeshAgent.speed = _moveToPlayerSpeed;
    }
}