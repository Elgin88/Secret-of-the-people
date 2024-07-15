using Scripts.CodeBase.Logic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    public class AgentMoveToPlayer : MonoBehaviour, IAgent
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private const float _moveSpeed = 2;
        private IGameFactory _iGameFactory;
        private Transform _playerTransform;

        public float MoveSpeed => _moveSpeed;

        public void EnableAgent()
        {
            Enable();
            SetMoveSpeed();
            NavMeshMoveOn();
            PlayAnimationMove();
        }

        public void DisableAgent()
        {
            NavMeshMoveOff();
            PlayAnimationIdle();
            Disable();
        }

        private void Awake()
        {
            SetComponents();
            Disable();
        }

        private void FixedUpdate()
        {
            MoveToTarget();
        }

        private void SetComponents()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _iGameFactory = AllServices.Container.Get<IGameFactory>();
            _navMeshAgent.speed = _moveSpeed;

            SetPlayerTransform();
        }

        private void SetPlayerTransform()
        {
            if (IsPlayerCreate())
            {
                SetPlayerTransfromFromGameFactory();
            }
            else
            {
                SetPlayerAfterCreate();
            }
        }

        private void SetPlayerAfterCreate() => _iGameFactory.PlayerLoaded += SetPlayerTransfromFromGameFactory;
        private bool IsPlayerCreate() => _iGameFactory.Player != null;
        private void SetPlayerTransfromFromGameFactory() => _playerTransform = _iGameFactory.Player.transform;
        private void NavMeshMoveOn() => _navMeshAgent.isStopped = false;
        private void NavMeshMoveOff() => _navMeshAgent.isStopped = true;
        private void Enable() => enabled = true;
        private void Disable() => enabled = false;
        private void PlayAnimationMove() => _enemyAnimator.PlayMove(_moveSpeed);
        private void PlayAnimationIdle() => _enemyAnimator.StopPlayMove();
        private void MoveToTarget() => _navMeshAgent.destination = _playerTransform.position;
        private void SetMoveSpeed() => _navMeshAgent.speed = _moveSpeed;
    }
}